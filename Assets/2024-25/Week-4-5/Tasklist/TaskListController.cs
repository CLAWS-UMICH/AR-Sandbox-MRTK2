//Ritij Jutur
//10/19/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit;
public class TaskListController : MonoBehaviour
{
    private Subscription<TasksDeletedEvent> tasksDeletedEvent;
    private Subscription<TasksEditedEvent> tasksEditedEvent;
    private Subscription<TasksAddedEvent> tasksAddedEvent;

    public GameObject taskListButtonPrefab;
    private TextMeshProUGUI id, status, description, shared_with, title;

    private Dictionary<int, GameObject> idToTask = new Dictionary<int, GameObject>();

    public ScrollHandler myScrollHandler;

    // Start is called before the first frame update
    void Start()
    {
        id = taskListButtonPrefab.transform.Find("ID").gameObject.GetComponent<TextMeshProUGUI>();
        status = taskListButtonPrefab.transform.Find("Status").gameObject.GetComponent<TextMeshProUGUI>();
        description = taskListButtonPrefab.transform.Find("Description").gameObject.GetComponent<TextMeshProUGUI>();
        shared_with = taskListButtonPrefab.transform.Find("SharedWith").gameObject.GetComponent<TextMeshProUGUI>();
        title = taskListButtonPrefab.transform.Find("Title").gameObject.GetComponent<TextMeshProUGUI>();
        // Subscribe to the events
        tasksDeletedEvent = EventBus.Subscribe<TasksDeletedEvent>(OnTasksDeleted);
        tasksEditedEvent = EventBus.Subscribe<TasksEditedEvent>(OnTasksEdited);
        tasksAddedEvent = EventBus.Subscribe<TasksAddedEvent>(OnTasksAdded);

        myScrollHandler = GameObject.Find("ScrollObjects").GetComponent<ScrollHandler>();

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
        foreach(TaskObj task in deletedWaypoints)
        {
            if(idToTask.ContainsKey(task.id))
            {
                myScrollHandler.HandleButtonDeletion(idToTask[task.id]);
                idToTask.Remove(task.id);
            }
        }    


    }
    private void OnTasksEdited(TasksEditedEvent e)
    {
        //Debug.Log("Edited");
        List<TaskObj> editedWaypoints = e.EditedTasks; // Which waypoints were edited (Look at their id's)

        foreach(TaskObj task in editedWaypoints)
        {
            if(idToTask.ContainsKey(task.id))
            {
                GameObject button = idToTask[task.id];
                button.transform.Find("ID").GetComponent<TextMeshProUGUI>().text = task.id.ToString();
                button.transform.Find("Status").GetComponent<TextMeshProUGUI>().text = task.status.ToString();
                button.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = task.title.ToString();
                button.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = task.description.ToString();
                button.transform.Find("SharedWith").GetComponent<TextMeshProUGUI>().text = task.shared_with.ToString();
            }
        }

        // Update the UI to reflect the edited waypoints
    }
    private void OnTasksAdded(TasksAddedEvent e)
    {
        List<TaskObj> newAddedWaypoints = e.NewAddedTasks; // Which waypoints are new

        foreach(TaskObj task in newAddedWaypoints)
        {
            id.text = task.id.ToString();
            status.text = task.status.ToString();
            description.text = task.description.ToString();
            shared_with.text = task.shared_with.ToString();
            title.text = task.title.ToString();

            GameObject new_button = myScrollHandler.HandleAddingButton(taskListButtonPrefab);
            idToTask.Add(task.id, new_button);
        }
    }

}