using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionChecklist : MonoBehaviour
{
    // Just for testing purposes
    [SerializeField] GameObject taskBox;
    [SerializeField] Sprite icon;
    [SerializeField] string testTitle = "Test";
    [SerializeField] string testDescription = "This is a description";

    private List<TaskBox> currentTasks = new List<TaskBox>();

    public void AddTask()
    {
        GameObject finalTaskBox = Instantiate(taskBox, gameObject.transform);

        TaskBox task = finalTaskBox.GetComponentInChildren<TaskBox>();

        task.ConstructTask(icon, testTitle, testDescription);
        currentTasks.Add(task);
    }

    public void FinishTask(TaskBox task)
    {
        currentTasks.Remove(task);
        Destroy(task);
    }
}
