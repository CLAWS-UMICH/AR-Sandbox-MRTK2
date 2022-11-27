using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionChecklist : MonoBehaviour
{
    // Just for testing purposes
    [SerializeField] GameObject taskBox;
    [SerializeField] Sprite icon;

    private List<TaskBox> currentTasks = new List<TaskBox>();

    public void AddTask()
    {
        string title = "Test";
        string desc = "This is a description";

        GameObject finalTaskBox = Instantiate(taskBox, gameObject.transform);

        TaskBox task = finalTaskBox.GetComponentInChildren<TaskBox>();

        task.ConstructTask(icon, title, desc);
        currentTasks.Add(task);
    }

    public void FinishTask(TaskBox task)
    {
        currentTasks.Remove(task);
        Destroy(task);
    }
}
