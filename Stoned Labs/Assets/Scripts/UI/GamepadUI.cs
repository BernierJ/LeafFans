using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadUI : MonoBehaviour
{
    [SerializeField] private StartUI _UI;
    private PlayerControls _controls;
    void Start()
    {
        _controls = new PlayerControls();
        _controls.StartMenu.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(_controls.StartMenu.Start.inProgress)
        {
            _controls.StartMenu.Disable();
            _UI.OnStartButton();
        }
        
        if(_controls.StartMenu.Controls.inProgress)
        {
            _UI.OnControlsButton();
        }

        if(_controls.StartMenu.Return.inProgress)
        {
            _UI.OnReturnButton();
        }
    }
}
