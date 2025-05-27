using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Canvas _controlsCanvas;
    void Start()
    {
        _controlsCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReturnButton()
    {
        //SceneManager.LoadScene("StartScreen");
        _controlsCanvas.gameObject.SetActive(false);
    }

    public void OnControlsButton()
    {
        //SceneManager.LoadScene("ControlsScreen");
        _controlsCanvas.gameObject.SetActive(true);
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("JosephTest");
    }
}
