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


    [SerializeField] private float _movementStrength;
    private Vector2 _leftJoystickDirection;
    private Vector2 _rightJoystickDirection;

    [SerializeField] private Transform _leftArm;
    [SerializeField] private Transform _rightArm;
    void Awake()
    {
        
        controls = new PlayerControls();
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
    }

    private void MoveLeftArm(Transform arm)
    {
     
        if(controls.Gameplay.LeftArmVertical.inProgress)
        {
            if (_leftJoystickDirection.y > 0)
            {
                arm.Translate(0, 0, 1*Time.deltaTime * _movementStrength);
            }
            else if(_leftJoystickDirection.y < 0)
            {
                arm.Translate(0, 0, -1*Time.deltaTime * _movementStrength);
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

    private void GrabRight(Transform obj)
    {
        //
        obj.position = transform.position;
    }

      private void GrabLeft(Transform obj)
    {
        //
        obj.position = transform.position;
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grabbable" && (controls.Gameplay.GrabLeft.inProgress || controls.Gameplay.GrabRight.inProgress))
        {
            controls.Gameplay.GrabRight.performed += ctx => GrabRight(collision.gameObject.transform);
            controls.Gameplay.GrabLeft.performed += ctx => GrabLeft(collision.gameObject.transform);
            
        }
    }
}
