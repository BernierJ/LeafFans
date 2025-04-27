using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

public class QTEButton : MonoBehaviour
{
    [SerializeField] public float _QTETimer; // max time for each QTE
    private float _timerCountdown;
    private PlayerControls _inputMap;

    private InputAction _buttonAction; // current button the QTE requires

    private bool _triggerQTE; // displays QTE UI when true
    private bool _inputIsCorrect;

    [SerializeField] private string[] _buttonNameSequence; //list of buttons the QTE will use

    private int _currentButton = 0;

    private IObservable<InputControl> buttonPress;

    private string _inputAction;

    //private InputControl _buttonControl;


    void OnEnable()
    {
        //m_EventListener = InputSystem.onAnyButtonPress.CallOnce(OnButtonPressed);
       // _receiveInput = _inputMap.QTEButtons.DownButton;
       // _receiveInput.Enable();
        //_button.performed += InputIsCorrect;

        _triggerQTE = true;

        
    }

    void OnDisable()
    {
        //m_EventListener.Dispose();
    }
    private void Awake()
    {
        
        _inputMap = new PlayerControls();
        
        SetButton(_buttonNameSequence[_currentButton]); // sets the first QTE to the first button in the list

        //_buttonControl = _buttonAction.activeControl;

    }

    private void Start()
    {
        _triggerQTE = true;
    }
    void Update()
    {

        //_receiveInput.inProgress;
        if (_triggerQTE)
        {
            _timerCountdown += Time.deltaTime;
            HandleInput();
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
        InputSystem.onAnyButtonPress.CallOnce(ctrl => StoreResult(ctrl));

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
        }
    }



    private void InputIsCorrect(string action)
    {
        

        if (action == _buttonAction.activeControl.name)
        {
            _inputIsCorrect = true;
            CorrectInput();
        }
        else
        {
            _inputIsCorrect = false;
            IncorrectInput();
        }

        Debug.Log("You entered " + action);

    }

    private void StoreResult(InputControl action)
    {
        _inputAction = action.name;

        InputIsCorrect(_inputAction);
        
    }


}
