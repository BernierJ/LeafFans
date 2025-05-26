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
    //public string objectName; // Name of the object
    // Example: Names of objects you want to outline
    [SerializeField] private List<GameObject> outlineObjectNames;

    void Start()
    {
        _panState.StepCompleted += DisplayNextTask;
        _taskText.text = _taskList[_taskIndex];
        UpdateOutlineForCurrentTask();
    }

    // Update is called once per frame
    void Update()
    {
        // check for what task the game is on
        // change the layer of the object from Not Outline to Outline
    }

    public void DisplayNextTask()
    {
        _taskIndex++;
        if (_taskIndex >= _taskList.Count)
        {
            _taskIndex = 0;
        }

        _taskText.text = _taskList[_taskIndex];
        UpdateOutlineForCurrentTask();
    }

    void UpdateOutlineForCurrentTask()
    {
        //depending on the _taskIndex. change the Layer of a game object
        
        if (_taskIndex == 0)
        {
            //outlineObjectNames[_taskIndex].layer = LayerMask.NameToLayer("Outline");
            SetLayerRecursively(outlineObjectNames[_taskIndex], LayerMask.NameToLayer("Outline"));
        }

        for (int i = 1; i < outlineObjectNames.Count; i++)
        {
            if (_taskIndex == i)
            {
                SetLayerRecursively(outlineObjectNames[_taskIndex - 1], LayerMask.NameToLayer("Not Outline"));
                SetLayerRecursively(outlineObjectNames[_taskIndex], LayerMask.NameToLayer("Outline"));
            }
        }
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

}
