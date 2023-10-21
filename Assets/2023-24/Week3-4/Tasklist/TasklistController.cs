using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit;
using JetBrains.Annotations;
using System.ComponentModel;
using UnityEngine.InputSystem.XR.Haptics;

public class TasklistController : MonoBehaviour
{

    private Subscription<TasksDeletedEvent> tasksDeletedEvent;
    private Subscription<TasksEditedEvent> tasksEditedEvent;
    private Subscription<TasksAddedEvent> tasksAddedEvent;
    private ScrollHandler scrollHandlerInstance;
    
    public GameObject preFab; //preFab for add Task
    public List<GameObject> listAllTasks; // all tasks
    public List<int> taskIDs; // all ids

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        tasksDeletedEvent = EventBus.Subscribe<TasksDeletedEvent>(OnTasksDeleted);
        tasksEditedEvent = EventBus.Subscribe<TasksEditedEvent>(OnTasksEdited);
        tasksAddedEvent = EventBus.Subscribe<TasksAddedEvent>(OnTasksAdded);

        scrollHandlerInstance = GetComponent<ScrollHandler>();
    }

    void OnDestroy()
    {
        // Unsubscribe when the script is destroyed
        if (tasksDeletedEvent != null)
        {
            EventBus.Unsubscribe(tasksDeletedEvent);
        }
        if (tasksEditedEvent != null)
        {
            EventBus.Unsubscribe(tasksEditedEvent);
        }
        if (tasksAddedEvent != null)
        {
            EventBus.Unsubscribe(tasksAddedEvent);
        }
    }

    private void OnTasksDeleted(TasksDeletedEvent e)
    {
        //Debug.Log("Deleted");
        List<TaskObj> deletedWaypoints = e.DeletedTasks; // Which waypoints were deleted (Look at their id's)
        foreach (TaskObj oneTask in deletedWaypoints)
        {
            int index = taskIDs.BinarySearch(oneTask.id);
            scrollHandlerInstance.HandleButtonDeletion(listAllTasks[index]);
            listAllTasks.RemoveAt(index);
            taskIDs.RemoveAt(index);
        }
        // Update the UI to reflect the deleted waypoints
    }

    private void OnTasksEdited(TasksEditedEvent e)
    {
        //Debug.Log("Edited");
        List<TaskObj> editedWaypoints = e.EditedTasks; // Which waypoints were edited (Look at their id's)
        foreach (TaskObj oneTask in editedWaypoints)
        {
            int index = taskIDs.BinarySearch(oneTask.id);

            GameObject button = GameObject.Find(listAllTasks[index].ToString());

            button.transform.Find("ID").gameObject.GetComponent<TextMeshPro>().text = oneTask.id.ToString();
            button.transform.Find("status").gameObject.GetComponent<TextMeshPro>().text = oneTask.status.ToString();
            button.transform.Find("title").gameObject.GetComponent<TextMeshPro>().text = oneTask.title;
            button.transform.Find("description").gameObject.GetComponent<TextMeshPro>().text = oneTask.description;
            button.transform.Find("shared_With").gameObject.GetComponent<TextMeshPro>().text = oneTask.shared_with.ToString();
        }
        // Update the UI to reflect the edited waypoints
    }

    private void OnTasksAdded(TasksAddedEvent e)
    {
        //Debug.Log("Added");

        List<TaskObj> newAddedWaypoints = e.NewAddedTasks; // Which waypoints are new
        foreach (TaskObj oneTask in newAddedWaypoints)
        {
            GameObject newTask = Instantiate(preFab, scrollHandlerInstance.transform);

            newTask.transform.Find("ID").gameObject.GetComponent<TextMeshPro>().text = oneTask.id.ToString();
            newTask.transform.Find("status").gameObject.GetComponent<TextMeshPro>().text = oneTask.status.ToString();
            newTask.transform.Find("title").gameObject.GetComponent<TextMeshPro>().text = oneTask.title;
            newTask.transform.Find("description").gameObject.GetComponent<TextMeshPro>().text = oneTask.description;
            newTask.transform.Find("shared_With").gameObject.GetComponent<TextMeshPro>().text = oneTask.shared_with.ToString();

            scrollHandlerInstance.Fix();

            listAllTasks.Add(newTask);
            taskIDs.Add(oneTask.id);
        }
        //Update the UI to reflect the new waypoints
    }
}
