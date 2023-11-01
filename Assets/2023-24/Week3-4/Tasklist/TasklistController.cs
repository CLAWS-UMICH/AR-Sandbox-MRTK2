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
    private ScrollHandler scrollHandlerInstance; // scrollHandler
    
    public GameObject preFab; //preFab for add Task
    public TextMeshPro id, title, description, shared_with, status; // textmeshpro
    public Dictionary<int, GameObject> taskWithID = new Dictionary<int, GameObject>(); // map with task and id


    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        id = preFab.transform.Find("ID").gameObject.GetComponent<TextMeshPro>();
        status = preFab.transform.Find("Status").gameObject.GetComponent<TextMeshPro>();
        title = preFab.transform.Find("Title").gameObject.GetComponent<TextMeshPro>();
        description = preFab.transform.Find("Description").gameObject.GetComponent<TextMeshPro>();
        shared_with = preFab.transform.Find("SharedWith").gameObject.GetComponent<TextMeshPro>();

        tasksDeletedEvent = EventBus.Subscribe<TasksDeletedEvent>(OnTasksDeleted);
        tasksEditedEvent = EventBus.Subscribe<TasksEditedEvent>(OnTasksEdited);
        tasksAddedEvent = EventBus.Subscribe<TasksAddedEvent>(OnTasksAdded);

        scrollHandlerInstance = GameObject.Find("ScrollObjects").GetComponent<ScrollHandler>();
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
            if (taskWithID.ContainsKey(oneTask.id))
            {
                scrollHandlerInstance.HandleButtonDeletion(taskWithID[oneTask.id]);
                taskWithID.Remove(oneTask.id);
            }
        }
        // Update the UI to reflect the deleted waypoints
    }

    private void OnTasksEdited(TasksEditedEvent e)
    {
        //Debug.Log("Edited");
        List<TaskObj> editedWaypoints = e.EditedTasks; // Which waypoints were edited (Look at their id's)
        foreach (TaskObj oneTask in editedWaypoints)
        {
            if (taskWithID.ContainsKey(oneTask.id))
            {
                GameObject editButton = taskWithID[oneTask.id];
                editButton.transform.Find("ID").gameObject.GetComponent<TextMeshPro>().text = "ID: " + oneTask.id.ToString();
                editButton.transform.Find("status").gameObject.GetComponent<TextMeshPro>().text = "Status: " + oneTask.status.ToString();
                editButton.transform.Find("title").gameObject.GetComponent<TextMeshPro>().text = "Title" + oneTask.title.ToString();
                editButton.transform.Find("description").gameObject.GetComponent<TextMeshPro>().text = "Description" + oneTask.description.ToString();
                editButton.transform.Find("shared_With").gameObject.GetComponent<TextMeshPro>().text = "Shared With" + oneTask.shared_with.ToString();

            }
            
        }
        // Update the UI to reflect the edited waypoints
    }

    private void OnTasksAdded(TasksAddedEvent e)
    {
        //Debug.Log("Added");

        List<TaskObj> newAddedWaypoints = e.NewAddedTasks; // Which waypoints are new
        foreach (TaskObj oneTask in newAddedWaypoints)
        {
            id.text = "ID: " + oneTask.id.ToString();
            status.text = "Status: " + oneTask.status.ToString();
            title.text = "Title: " + oneTask.title.ToString();
            description.text = "Description: " + oneTask.description.ToString();
            shared_with.text = "Shared With: " + oneTask.shared_with.ToString();

            GameObject newButton = scrollHandlerInstance.HandleAddingButton(preFab);
            taskWithID.Add(oneTask.id, newButton);
        }
        //Update the UI to reflect the new waypoints
    }
}
