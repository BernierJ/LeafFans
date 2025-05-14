using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETriggerHandler : MonoBehaviour
{
    public PanStateManager panStateManager;
    public string targetName; // Name of the butter object

    private void OnTriggerEnter(Collider other)
    {
        // Check for butter
        targetName = "cannabutterstick";
        if (other.gameObject.name == targetName)
        {
            Debug.Log("Butter object entered trigger zone. Switching pan state...");

            if (panStateManager != null)
            {
                panStateManager.SwitchToNextPan();
            }

            other.gameObject.SetActive(false); // Disable the butter
        }

        // Check for pile of rice cripsies
        targetName = "pileofcrispies";
        if (other.gameObject.name == targetName)
        {
            Debug.Log("Pile of cripies object entered trigger zone. Switching pan state...");

            if (panStateManager != null)
            {
                panStateManager.SwitchToNextPan();
            }

            other.gameObject.SetActive(false); // Disable the butter
        }

        // Check for Spoon
        targetName = "Spoon";
        if (other.gameObject.name == targetName)
        {
            Debug.Log("Spoon object entered trigger zone. Switching pan state...");

            if (panStateManager != null)
            {
                panStateManager.SwitchToNextPan();
            }

            other.gameObject.SetActive(false); // Disable the butter
        }
    }
}
