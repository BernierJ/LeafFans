using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QTETriggerHandler : MonoBehaviour
{
    public PanStateManager panStateManager;
    public string targetName; // Name of the object

    private GameObject Spoon2;
    private GameObject RiceKrispies;
    

    void Start()
    {
    }

    private GameObject FindInactiveObjectByName(string name)
    {
        var rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (var root in rootObjects)
        {
            var transforms = root.GetComponentsInChildren<Transform>(true); // true = include inactive
            foreach (var t in transforms)
            {
                if (t.name == name)
                    return t.gameObject;
            }
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for butter
        targetName = "cannabutterstick";
        if (other.gameObject.name == targetName && panStateManager.currentIndex == 0)
        {
            Debug.Log("Butter object entered trigger zone. Switching pan state...");

            if (panStateManager != null && panStateManager.currentIndex == 0)
            {
                panStateManager.SwitchToNextPan();
            }

            other.gameObject.SetActive(false); // Disable the butter
        }

        // Check for Marshmallows
        targetName = "Marshmallows";
        if (other.gameObject.name == targetName && panStateManager.currentIndex == 1)
        {
            Debug.Log("Spoon object entered trigger zone. Switching pan state...");

            if (panStateManager != null && panStateManager.currentIndex == 1)
            {
                panStateManager.SwitchToNextPan();
            }

            other.gameObject.SetActive(false); // Disable the butter
        }

        // Check for Spoon
        targetName = "Spoon-1";
        if (other.gameObject.name == targetName && panStateManager.currentIndex == 2)
        {
            Debug.Log("Spoon object entered trigger zone. Switching pan state...");

            if (panStateManager != null && panStateManager.currentIndex == 2)
            {
                panStateManager.SwitchToNextPan();
            }

            other.gameObject.SetActive(false); // Disable the spoon

            Spoon2 = FindInactiveObjectByName("Spoon-2");

            if (Spoon2 != null)
            {
                Spoon2.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Spoon-2 not found in scene.");
            }
        }

        // Check for pile of rice cripsies
        targetName = "pileofcrispies";
        if (other.gameObject.name == targetName && panStateManager.currentIndex == 3)
        {
            Debug.Log("Pile of cripies object entered trigger zone. Switching pan state...");

            if (panStateManager != null && panStateManager.currentIndex == 3)
            {
                panStateManager.SwitchToNextPan();
            }

            other.gameObject.SetActive(false); // Disable the butter
        }

        // Check for pile of rice cripsies
        targetName = "Spoon-2";
        if (other.gameObject.name == targetName && panStateManager.currentIndex == 4)
        {
            Debug.Log("Spoon object entered trigger zone. Switching pan state...");

            if (panStateManager != null && panStateManager.currentIndex == 4)
            {
                panStateManager.SwitchToNextPan();
            }

            other.gameObject.SetActive(false); // Disable the butter

            //RiceKrispies = FindInactiveObjectByName("Rice Krispies");
        }

        /*
        targetName = "riceKrispiesDone"; // what to go here???
        if (other.gameObject.name == targetName && panStateManager.currentIndex == 5)
        {
            Debug.Log("Triggered by object: " + other.gameObject.name);
            //Debug.Log("Spoon object entered trigger zone. Switching pan state...");

            if (panStateManager != null && panStateManager.currentIndex == 5)
            {
                if (RiceKrispies != null)
                {
                    RiceKrispies.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Rice Krispies not found in scene.");
                }

                //panStateManager.SwitchToNextPan();
            }

        }
        */
        



    }
}
