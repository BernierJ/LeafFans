using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanStateManager : MonoBehaviour
{
    public List<GameObject> pans;  // Assign in Inspector
    private int currentIndex = 0;

    public delegate void PanDelegate();
    public event PanDelegate StepCompleted;

    void Start()
    {
        SetActivePan(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToNextPan();
        }
    }

    public void SwitchToNextPan()
    {
        currentIndex = (currentIndex + 1) % pans.Count;
        SetActivePan(currentIndex);
        StepCompleted?.Invoke();
    }

    void SetActivePan(int index)
    {
        for (int i = 0; i < pans.Count; i++)
        {
            pans[i].SetActive(i == index);
        }
    }
}
