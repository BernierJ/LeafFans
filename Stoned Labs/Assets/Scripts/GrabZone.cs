using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabZone : MonoBehaviour
{
    public GameObject heldObject;

    private void Update()
    {
        // Auto-clear reference if the object is inactive
        if (heldObject != null && !heldObject.activeInHierarchy)
        {
            heldObject = null;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (heldObject == null && other.CompareTag("Grabbable"))
        {
            heldObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (heldObject == other.gameObject)
        {
            heldObject = null;
        }
    }

}
