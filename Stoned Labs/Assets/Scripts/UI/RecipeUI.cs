using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _taskText;
    [SerializeField] private PanStateManager _panState;

    [SerializeField] private List<string> _taskList;
    private int _taskIndex = 0;
    void Start()
    {
        _panState.StepCompleted += DisplayNextTask;
        _taskText.text = _taskList[_taskIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayNextTask()
    {
        _taskIndex++;
        if(_taskIndex >= _taskList.Count)
        {
            _taskIndex = 0;
        }

        _taskText.text = _taskList[_taskIndex];
    }
}
