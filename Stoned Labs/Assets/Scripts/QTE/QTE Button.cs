using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEButton : MonoBehaviour
{

    [SerializeField] private float _QTETimer;
    [SerializeField] private PlayerControls _input;

    private PlayerControls.GameplayActions _button;

    private bool _triggerQTE;

    [SerializeField] private string buttonName;

    
    private void Start()
    {
        _button = _input.Gameplay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
