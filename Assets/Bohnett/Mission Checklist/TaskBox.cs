using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskBox : MonoBehaviour
{
    private const string taskIconTag = "TaskIcon";
    private const string taskTitleTag = "TaskTitle";
    private const string taskDescriptionTag = "TaskDescription";

    public void ConstructTask(Sprite taskIcon, string taskTitle, string taskDescription)
    {
        Debug.Log(taskTitle);
        Debug.Log(taskDescription);

        var allChildren = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.tag == taskIconTag)
            {
                child.GetComponent<Image>().sprite = taskIcon;
            }

            if (child.tag == taskTitleTag)
            {
                child.GetComponent<TextMeshProUGUI>().text = taskTitle;
            }

            if (child.tag == taskDescriptionTag)
            {
                child.GetComponent<TextMeshProUGUI>().text = taskDescription;
            }
        }
        
    }

    public void RemoveFromChecklist()
    {
        FindObjectOfType<MissionChecklist>().FinishTask(this);
    }

}
