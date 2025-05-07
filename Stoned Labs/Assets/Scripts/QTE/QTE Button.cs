using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

public class QTEButton : MonoBehaviour
{
    [SerializeField] private QTEUI _QTEUI;
    [SerializeField] public float _QTETimer; // max time for each QTE
    private float _timerCountdown;
    private PlayerControls _inputMap;

    private InputAction _buttonAction; // current button the QTE requires

    private bool _triggerQTE; // displays QTE UI when true
    private bool _inputIsCorrect;

    [SerializeField] private string[] _buttonNameSequence; //list of buttons the QTE will use

    private int _currentButton = 0;

    //private IObservable<InputAction> buttonPress;

    private InputAction _inputAction;

    //private bool _buttonPressed;

    public delegate void QTEDelegate();
    public QTEDelegate QTEChainCompleted;

    public QTEDelegate QTESingleCompleted;

    public QTEDelegate QTEFailed;

    public QTEDelegate QTEStarted;


    [SerializeField] PlayerInput _playerInput;
    //private InputControl _buttonControl;


    void OnEnable()
    {
        //m_EventListener = InputSystem.onAnyButtonPress.CallOnce(OnButtonPressed);
       // _receiveInput = _inputMap.QTEButtons.DownButton;
       // _receiveInput.Enable();
        //_button.performed += InputIsCorrect;

        _triggerQTE = true;

        _inputMap.QTEButtons.Enable();

        QTEStarted?.Invoke();

        _QTEUI.gameObject.SetActive(true);

        
    }

    void OnDisable()
    {
        //m_EventListener.Dispose();
        _inputMap.QTEButtons.Disable();
        _QTEUI.gameObject.SetActive(false);
    }
    private void Awake()
    {
        
        _inputMap = new PlayerControls();
        
        SetButton(_buttonNameSequence[_currentButton]); // sets the first QTE to the first button in the list

        

        

        //_buttonControl = _buttonAction.activeControl;

    }

    private void Start()
    {
        
    }
    void Update()
    {

        //_receiveInput.inProgress;
        if (_triggerQTE)
        {
            _timerCountdown += Time.deltaTime;
            //HandleInput();

            HandleInputLite();

            
        }
        
    
        
    }

    private void SetButton(string button)
    {
        _buttonAction = _inputMap.FindAction(button);
        Debug.Log($"ButtonSet to {_buttonAction.name}");
        //_buttonControl = _buttonAction.activeControl;
    }

    private void HandleInput()
    {
        InputSystem.onAnyButtonPress.Call(_inputAction => 
        {
            StoreResult(_inputAction);
        });

    }

    private void CorrectInput()
    {
        if(_inputIsCorrect && _timerCountdown < _QTETimer)
        {
            Debug.Log("SUCCESS");
            _currentButton++;
            SetButton(_buttonNameSequence[_currentButton]);
            _timerCountdown = 0;

            _inputIsCorrect = false;
        }
    }

    private void IncorrectInput()
    {
        if (_timerCountdown > _QTETimer)
        {
            Debug.Log("FAILURE");
            _currentButton = 0;
            SetButton(_buttonNameSequence[_currentButton]);
            _timerCountdown = 0;

            QTEFailed?.Invoke();
        }
    }



    private void InputIsCorrect(string action)
    {
        

        if (_inputAction.inProgress && _buttonAction.inProgress)
        {
            _inputIsCorrect = true;
            CorrectInput();
        }
        /*else
        {
            _inputIsCorrect = false;
            IncorrectInput();
        } */

        Debug.Log("You entered " + action);

    }

    private void StoreResult(InputControl action)
    {
       // _inputAction = action.;

        //InputIsCorrect(_inputAction);
        
    }

    private void HandleInputLite()
    {

        if(_buttonAction.WasPressedThisFrame())
        {
            SimpleSuccess();
        }

        /*OnTest1();

        if (_buttonAction.inProgress)
        {
            SimpleSuccess();

        } */

        if(_timerCountdown > _QTETimer)
        {
            IncorrectInput();
        }
    }

    private void SimpleSuccess()
    {
        Debug.Log("SUCCESS");
            _currentButton++;
            if(_currentButton >= _buttonNameSequence.Length)
            {
                _currentButton = 0;

                QTEChainCompleted?.Invoke();
                gameObject.SetActive(false);
            }
            SetButton(_buttonNameSequence[_currentButton]);
            _timerCountdown = 0;
            
            QTESingleCompleted?.Invoke();
    }

    /*public void OnTest1()
    {
        if(_inputMap.QTEButtons.Test1.inProgress)
        {
            SimpleSuccess();
        }
        else
        {
            IncorrectInput();
        }
    } */


}
