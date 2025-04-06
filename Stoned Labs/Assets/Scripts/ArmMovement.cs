using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmMovement : MonoBehaviour
{
    PlayerControls controls;
    [SerializeField] private float _movementStrength;
    private Vector2 _leftDirection;
    private Vector2 _rightDirection;

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

    }

    private void Update()
    {
        _leftDirection = controls.Gameplay.MoveLeftArm.ReadValue<Vector2>();
        _rightDirection = controls.Gameplay.MoveRightArm.ReadValue<Vector2>();

        MoveLeftArm(_leftArm);
        MoveRightArm(_rightArm);
    }

    private void MoveLeftArm(Transform arm)
    {
        arm.Translate(_leftDirection * Time.deltaTime * _movementStrength);
    }

     private void MoveRightArm(Transform arm)
    {
        arm.Translate(_rightDirection * Time.deltaTime * _movementStrength);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
