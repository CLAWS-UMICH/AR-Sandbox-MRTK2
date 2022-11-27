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
        foreach (Transform child in gameObject.transform)
        {
            Debug.Log(child);
            if (child.tag == taskIconTag)
            {
                Debug.Log("FLup");
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

    public void RemoveFromChecklist()
    {
        FindObjectOfType<MissionChecklist>().FinishTask(this);
    }

}
