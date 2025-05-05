using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butter : MonoBehaviour
{
    [SerializeField] PanStateManager _panState;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hot")
        {
            _panState.SwitchToNextPan();
            Destroy(gameObject);
        }
    }

   
}
