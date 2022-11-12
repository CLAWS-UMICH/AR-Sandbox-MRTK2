using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskBox : MonoBehaviour
{
    // Add something for when they are checked?
    private Sprite taskIcon;
    private string taskTitle;
    private string taskDescription;

    private const string taskIconTag = "TaskIcon";
    private const string taskTitleTag = "TaskTitle";
    private const string taskDescriptionTag = "TaskDescription";


    public TaskBox(Sprite taskIconIn, string taskTitleIn, string taskDescriptionIn)
    {
        taskIcon = taskIconIn;
        taskTitle = taskTitleIn;
        taskDescription = taskDescriptionIn;
    }

    private void Start()
    {
        ConstructTask();
    }

    private void ConstructTask()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.tag == taskIconTag)
            {
                child.GetComponent<Image>().sprite = taskIcon;
            }

            if (child.tag == taskTitleTag)
            {
                child.GetComponent<TextMeshPro>().text = taskTitle;
            }

            if (child.tag == taskDescriptionTag)
            {
                child.GetComponent<TextMeshPro>().text = taskDescription;
            }
        }
        
    }

}
