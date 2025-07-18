using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGrabber : MonoBehaviour
{
    public GrabZone grabZone;
    public Transform grabPoint;

    // These will be set externally by the input manager
    public bool grabPressed;

    //private FixedJoint joint;

    void FixedUpdate()
    {
        if (grabPressed && grabZone.heldObject != null) // && joint == null
        {
            /*Rigidbody targetRb = grabZone.heldObject.GetComponent<Rigidbody>();
            if (targetRb != null)
            {
                joint = grabPoint.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = targetRb;
            } */

            grabZone.heldObject.transform.position = grabZone.transform.position;

            if(!grabZone.heldObject.GetComponent<Rigidbody>().isKinematic)
            {
                grabZone.heldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            
        }

        if (!grabPressed) //&& joint != null)
        {
           // Destroy(joint);
            //joint = null;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
