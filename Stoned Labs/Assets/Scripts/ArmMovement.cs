using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmMovement : MonoBehaviour
{
    PlayerControls controls;

    
    public ArmGrabber leftArm;
    public ArmGrabber rightArm;

    [SerializeField] private CameraSwitcher _camera;
    [SerializeField] private float _movementStrength;
    private Vector2 _leftJoystickDirection;
    private Vector2 _rightJoystickDirection;

    [SerializeField] private Transform _leftArm;
    [SerializeField] private Transform _rightArm;

    [SerializeField] private QTEButton _QTE;

    //[SerializeField] private Rigidbody leftArmRigidbody;

    private bool _changeAngle;
    void Awake()
    {

        controls = new PlayerControls();

        _QTE.QTEStarted += DisableControls;
        _QTE.QTEChainCompleted += EnableControls;
    /*
                    controls.Gameplay.MoveLeftArm.performed += ctx => _leftDirection = ctx.ReadValue<Vector2>();
                    controls.Gameplay.MoveLeftArm.canceled += ctx => _leftDirection = Vector2.zero;

                    controls.Gameplay.MoveRightArm.performed += ctx => _rightDirection = ctx.ReadValue<Vector2>();
                    controls.Gameplay.MoveRightArm.canceled += ctx => _rightDirection = Vector2.zero; */

        // Arm movement not shown here, just grab input
        //controls.Gameplay.GrabLeft.performed += ctx => leftArm.grabPressed = true;
        //controls.Gameplay.GrabLeft.canceled += ctx => leftArm.grabPressed = false;

        //controls.Gameplay.GrabRight.performed += ctx => rightArm.grabPressed = true;
        //controls.Gameplay.GrabRight.canceled += ctx => rightArm.grabPressed = false;

    }

    private void EnableControls()
    {
        controls.Gameplay.Enable();
    }

    private void DisableControls()
    {
        controls.Gameplay.Disable();
    }

    private void Update()
    {
        // arm movement
        _leftJoystickDirection = controls.Gameplay.MoveLeftArm.ReadValue<Vector2>();
        _rightJoystickDirection = controls.Gameplay.MoveRightArm.ReadValue<Vector2>();

        // arm grabbing
        controls.Gameplay.GrabLeft.performed += ctx => leftArm.grabPressed = true;
        controls.Gameplay.GrabLeft.canceled += ctx => leftArm.grabPressed = false;

        controls.Gameplay.GrabRight.performed += ctx => rightArm.grabPressed = true;
        controls.Gameplay.GrabRight.canceled += ctx => rightArm.grabPressed = false;


        MoveLeftArm(_leftArm);
        MoveRightArm(_rightArm);
        CameraInput();
    }

    private void MoveLeftArm(Transform arm)
    {
     
        if(controls.Gameplay.LeftArmVertical.inProgress)
        {
            if (_leftJoystickDirection.y > 0)
            {
                arm.Translate(0, 0, 1*Time.deltaTime * _movementStrength);

                //leftArmRigidbody.Move(Vector3.forward * Time.deltaTime * _movementStrength, Quaternion.identity);
            }
            else if (_leftJoystickDirection.y < 0)
            {
                arm.Translate(0, 0, -1 * Time.deltaTime * _movementStrength);
                //leftArmRigidbody.Move(Vector3.back * Time.deltaTime * _movementStrength, Quaternion.identity);
            }
            if (_leftJoystickDirection.x > 0)
            {
                arm.Translate(1*Time.deltaTime*_movementStrength, 0, 0);
            }
            else if(_leftJoystickDirection.x < 0)
            {
                arm.Translate(-1*Time.deltaTime * _movementStrength, 0, 0);
            }
        }
        else
        {
            arm.Translate(_leftJoystickDirection * Time.deltaTime * _movementStrength);
        }
    }

     private void MoveRightArm(Transform arm)
    {
        if(controls.Gameplay.RightArmVertical.inProgress)
        {
            if (_rightJoystickDirection.y > 0)
            {
                arm.Translate(0, 0, 1*Time.deltaTime * _movementStrength);
            }
            else if(_rightJoystickDirection.y < 0)
            {
                arm.Translate(0, 0, -1*Time.deltaTime * _movementStrength);
            }
            
            if (_rightJoystickDirection.x > 0)
            {
                arm.Translate(1*Time.deltaTime*_movementStrength, 0, 0);
            }
            else if(_rightJoystickDirection.x < 0)
            {
                arm.Translate(-1*Time.deltaTime * _movementStrength, 0, 0);
            }
        }
        else
        {
            arm.Translate(_rightJoystickDirection * Time.deltaTime * _movementStrength);
        }
    }


    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void CameraInput()
    {
        if(controls.Gameplay.ChangeCamera.inProgress)
        {
            _camera.ChangeCameraAngle();
        }
    }

   
}
