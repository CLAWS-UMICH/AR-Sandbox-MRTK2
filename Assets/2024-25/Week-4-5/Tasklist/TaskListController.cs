using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TaskListController : MonoBehaviour
{
    private Subscription<TasksDeletedEvent> tasksDeletedEvent;
    private Subscription<TasksEditedEvent> tasksEditedEvent;
    private Subscription<TasksAddedEvent> tasksAddedEvent;
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        tasksDeletedEvent = EventBus.Subscribe<TasksDeletedEvent>(OnTasksDeleted);
        tasksEditedEvent = EventBus.Subscribe<TasksEditedEvent>(OnTasksEdited);
        tasksAddedEvent = EventBus.Subscribe<TasksAddedEvent>(OnTasksAdded);
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
        // Update the UI to reflect the deleted waypoints
    }
    private void OnTasksEdited(TasksEditedEvent e)
    {
        //Debug.Log("Edited");
        List<TaskObj> editedWaypoints = e.EditedTasks; // Which waypoints were edited (Look at their id's)
        // Update the UI to reflect the edited waypoints
    }
    private void OnTasksAdded(TasksAddedEvent e)
    {
        //Debug.Log("Added");
        List<TaskObj> newAddedWaypoints = e.NewAddedTasks; // Which waypoints are new
        // Update the UI to reflect the new waypoints
    }
}