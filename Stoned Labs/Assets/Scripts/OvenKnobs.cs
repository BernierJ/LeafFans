using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenKnobs : MonoBehaviour
{
    [SerializeField] private ArmGrabber _leftArm;
    [SerializeField] private ArmGrabber _rightArm;
    [SerializeField] private ParticleSystem _particles;

    // Start is called before the first frame update
    void Start()
    {
        
        _particles.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision collision)
    {
        if(_leftArm.grabPressed || _rightArm.grabPressed)
        {
            _particles.gameObject.SetActive(true);
            Debug.Log("VFX ON");
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if((_leftArm.grabPressed || _rightArm.grabPressed) && _particles.isPlaying)
            {
                _particles.gameObject.SetActive(false);
                Debug.Log("VFX OFF");
            
            }   
    }
}
