using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    PlayerControls controls;

    private bool _changeAngle;
    public Cinemachine.CinemachineVirtualCamera firstPersonCam;
    public Cinemachine.CinemachineVirtualCamera topDownCam;

    void Start()
    {
        firstPersonCam.Priority = 10;
        topDownCam.Priority = 0;
        controls = new PlayerControls();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C) || _changeAngle)
        {
            ChangeCameraAngle();
        }
    }

    public void ChangeCameraAngle()
    {
        //Debug.Log("Key pressed");
            bool isFirstPerson = firstPersonCam.Priority > topDownCam.Priority;
            firstPersonCam.Priority = isFirstPerson ? 0 : 10;
            topDownCam.Priority = isFirstPerson ? 10 : 0;
    }
}
