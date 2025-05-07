using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEUI : MonoBehaviour
{
    [SerializeField] private QTEButton _QTEActions;
    [SerializeField] private List<GameObject> _QTEImages;

    private int _index;
    void Start()
    {
        _index = 0;
        //_QTEActions.QTEChainCompleted += methodName
        //_QTEActions.QTEFailed += 
        //_QTEActions.QTESingleCompleted +=
        _QTEActions.QTEStarted += DisplayNextImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        _index = 0;
    }
    private void DisplayNextImage()
    {
        if(_index <= _QTEImages.Count)
        {
            _QTEImages[_index].SetActive(true);
            if(_index >= 1)
            {
                _QTEImages[_index - 1].SetActive(false);
            }
            _index++;
        }
        else 
        {
            _index = 0;
        }
        

    }

    private void Disable()
    {
        enabled = false;
    }


}
