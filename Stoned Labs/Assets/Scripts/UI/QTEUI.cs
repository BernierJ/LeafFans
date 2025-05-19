using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEUI : MonoBehaviour
{
    [SerializeField] private QTEButton _QTEActions;
    [SerializeField] private List<GameObject> _QTEImages; // 0 is up, 1 right, 2 down, 3 left
    [SerializeField] private PanStateManager _panState;

    [SerializeField] private ParticleSystem _particles;

    public delegate void QTEDisplay();
    public QTEDisplay DisplaySuccess;

    private int _index;
    void Start()
    {
        

        _index = 0;
        //_QTEActions.QTEChainCompleted += methodName
        //_QTEActions.QTEFailed += 
        //_QTEActions.QTESingleCompleted +=


        // _QTEActions.QTEStarted += DisplayNextImage;

        // _QTEActions.QTESingleCompleted += DisplayNextImage;
        _QTEActions.QTEFailed += Restart;
        _QTEActions.QTEChainCompleted += Success;
        _QTEActions.ImageName += DisplayImageByName;
        _QTEActions.QTESingleCompleted += SingleSuccess;

        _panState.StepCompleted += StartQTE;
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
        if (_index <= _QTEImages.Count)
        {
            _QTEImages[_index].SetActive(true);
            if (_index >= 1)
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

    private void DisplayImageByName(string QTEName)
    {
        _QTEImages[0].SetActive(false);
        _QTEImages[1].SetActive(false);
        _QTEImages[2].SetActive(false);
        _QTEImages[3].SetActive(false);

        if (QTEName.Contains("Up"))
        {
            _QTEImages[0].SetActive(true);
        }
        if (QTEName.Contains("Right"))
        {
            _QTEImages[1].SetActive(true);
        }
        if (QTEName.Contains("Down"))
        {
            _QTEImages[2].SetActive(true);
        }
        if (QTEName.Contains("Left"))
        {
            _QTEImages[3].SetActive(true);
        }
    }

    private void Disable()
    {
        enabled = false;
    }

    private void Restart()
    {
        _index = 0;
        // DisplayNextImage();
    }

    private void Success()
    {
        DisplaySuccess?.Invoke();
        //_QTEActions.gameObject.SetActive(false);
    }

    private void StartQTE()
    {
        _QTEActions.gameObject.SetActive(true);
    }

    private void SingleSuccess()
    {
        _particles.Play();
    }

}
