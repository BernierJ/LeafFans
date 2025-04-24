using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QTEButton : MonoBehaviour
{

    [SerializeField] private float _QTETimer; // max time for each QTE
    private float _timerCountdown;
    private PlayerControls _inputMap;
    private InputAction _receiveInput;

    private InputAction _button; // current button the QTE requires

    private bool _triggerQTE; // displays QTE UI when true
    private bool _inputReceived;

    [SerializeField] private string[] _buttonNameSequence; //list of buttons the QTE will use

    private int _currentButton = 0;

    private void Awake()
    {
        _receiveInput = new InputAction();
        _inputMap = new PlayerControls();
    }

    private void Start()
    {
        SetButton(_buttonNameSequence[_currentButton]); // sets the first QTE to the first button in the list
        _triggerQTE = true;

        
    }

    // Update is called once per frame
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
        _button = _inputMap.FindAction(button);
        Debug.Log("ButtonSet");
    }

    private void HandleInput()
    {
        //_receiveInput.onActionTriggered += context =>
        //{
            if(_button.WasPressedThisFrame() && _timerCountdown < _QTETimer)
            {
                Debug.Log("SUCCESS");
                _currentButton++;
                SetButton(_buttonNameSequence[_currentButton]);
                _timerCountdown = 0;
            }
            else if (_timerCountdown > _QTETimer)  //|| )
            {
                Debug.Log("FAILURE");
                _currentButton = 0;
                SetButton(_buttonNameSequence[_currentButton]);
                _timerCountdown = 0;
            }
        //};
        
    }



}
