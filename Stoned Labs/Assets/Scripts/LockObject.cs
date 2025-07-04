using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObject : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lock")
        {
            GetComponentInParent<Rigidbody>().isKinematic = true;

            GetComponentInParent<LockSelf>().Lock();


            transform.position = other.transform.position;


            GetComponentInParent<Transform>().tag = "Locked";
        }
        else
        {
            Debug.Log("This object is not locked");
            return;
        }
    }
}
