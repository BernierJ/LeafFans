using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceKrispiesActivator : MonoBehaviour
{
    public GameObject riceKrispiesDone;   // Assign in Inspector
    public GameObject riceKrispies;       // Assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered is riceKrispiesDone
        if (other.gameObject == riceKrispiesDone)
        {
            // Activate Rice Krispies and all its children
            SetActiveRecursively(riceKrispies, true);

            // Deactivate riceKrispiesDone
            riceKrispiesDone.SetActive(false);

            Debug.Log("Rice Krispies activated, riceKrispiesDone deactivated!");
        }
    }

    // Helper function to recursively activate a GameObject and all children
    private void SetActiveRecursively(GameObject obj, bool state)
    {
        obj.SetActive(state);
        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetActive(state);
        }
    }
}
