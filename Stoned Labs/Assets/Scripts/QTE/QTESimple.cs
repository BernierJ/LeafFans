using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;


public class QTESimple : MonoBehaviour
{
    [SerializeField] public float _QTETimer;

    private float _timerCountdown;

    private PlayerControls _inputMap;

    public InputAction _buttonAction;

    private bool _triggerQTE;

    [SerializeField] private string[] _buttonNameSequence; //list of buttons the QTE will use

    private int _currentButton = 0;

    private string _inputName;
    private bool _inputIsCorrectinput;
    
    void Start()
    {
        _triggerQTE = true;
    }

    private void Awake()
    {
        _inputMap = new PlayerControls();
        
        SetButton(_buttonNameSequence[_currentButton]); 

        

        
    }

    void Onable()
    {
        _triggerQTE = true;
    }

    // Update is called once per frame
    void Update()
    {
        //_inputIsCorrectinput = _buttonAction.IsPressed();
        _buttonAction.performed += ctx => _inputIsCorrectinput = true;
        
        if (_triggerQTE)
        {
            _timerCountdown += Time.deltaTime;

            if( _inputIsCorrectinput && _timerCountdown < _QTETimer)//_inputName == _buttonNameSequence[_currentButton] && _timerCountdown < _QTETimer)
            {
                Debug.Log("SUCCESS");
                _currentButton++;
                SetButton(_buttonNameSequence[_currentButton]);
                _timerCountdown = 0;

            
            }
            if (_timerCountdown > _QTETimer)
            {
                Debug.Log("FAILURE");
                _currentButton = 0;
                SetButton(_buttonNameSequence[_currentButton]);
                _timerCountdown = 0;
            }
        }
    }

     private void SetButton(string button)
    {
        _buttonAction = _inputMap.FindAction(button);
        Debug.Log($"ButtonSet to {_buttonAction.name}");
        //_buttonControl = _buttonAction.activeControl;
    }

    private void StoreActionString(InputAction.CallbackContext input)
    {
        _inputName = input.action.name;
        Debug.Log($"input: {input.action.name}");
    }
}

