using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointController : MonoBehaviour
{

    private Subscription<WaypointsDeletedEvent> waypointsDeletedEvent;
    private Subscription<WaypointsEditedEvent> waypointsEditedEvent;
    private Subscription<WaypointsAddedEvent> waypointsAddedEvent;

    private ScrollHandler scrollHandler;

    private GameObject buttonList;

    [SerializeField] private GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        // Subscribe to the events
        waypointsDeletedEvent = EventBus.Subscribe<WaypointsDeletedEvent>(OnWaypointsDeleted);
        waypointsEditedEvent = EventBus.Subscribe<WaypointsEditedEvent>(OnWaypointsEdited);
        waypointsAddedEvent = EventBus.Subscribe<WaypointsAddedEvent>(OnWaypointsAdded);
        buttonList = GameObject.Find("ButtonList");
        scrollHandler = GameObject.Find("ScrollObjects").GetComponent<ScrollHandler>();
    }

    void OnDestroy()
    {
        // Unsubscribe when the script is destroyed
        if (waypointsDeletedEvent != null)
        {
            EventBus.Unsubscribe(waypointsDeletedEvent);
        }
        if (waypointsEditedEvent != null)
        {
            EventBus.Unsubscribe(waypointsEditedEvent);
        }
        if (waypointsAddedEvent != null)
        {
            EventBus.Unsubscribe(waypointsAddedEvent);
        }
    }

    private void OnWaypointsDeleted(WaypointsDeletedEvent e)
    {
        Debug.Log("Deleted");
        List<Waypoint> deletedWaypoints = e.DeletedWaypoints; // Which waypoints were deleted (Look at their id's)

        // Update the UI to reflect the deleted waypoints
        foreach (Waypoint waypoint in deletedWaypoints)
        {
            // Find the button GameObject associated with the deleted waypoint
            GameObject deletedButton = FindButtonByID(waypoint.id);

            if (deletedButton != null)
            {
                // Remove the button using ScrollHandler
                scrollHandler.HandleButtonDeletion(deletedButton);
            }
        }
    }

    private void OnWaypointsEdited(WaypointsEditedEvent e)
    {
        Debug.Log("Edited");
        List<Waypoint> editedWaypoints = e.EditedWaypoints; // Which waypoints were edited (Look at their id's)

        // Update the UI to reflect the edited waypoints
        foreach (Waypoint waypoint in editedWaypoints)
        {
            // Find the button GameObject associated with the edited waypoint
            GameObject editedButton = FindButtonByID(waypoint.id);

            if (editedButton != null)
            {
                // Update the button's text fields with the new waypoint data
                UpdateButtonText(editedButton, waypoint);
            }
        }
    }

    private void OnWaypointsAdded(WaypointsAddedEvent e)
    {
        Debug.Log("Added");
        List<Waypoint> newAddedWaypoints = e.NewAddedWaypoints; // Which waypoints are new

        // Update the UI to reflect the new waypoints
        foreach (Waypoint waypoint in newAddedWaypoints)
        {
            // Create a new button GameObject from the prefab
            GameObject newButton = Instantiate(buttonPrefab);

            // Populate the new button's text fields with waypoint data
            UpdateButtonText(newButton, waypoint);

            // Add the new button using ScrollHandler
            scrollHandler.HandleAddingButton(newButton);
        }
    }

    private GameObject FindButtonByID(int id)
    {
        foreach (Transform child in buttonList.transform)
        {
            if (child.name == "ID" && child.GetComponent<Text>().text == id.ToString())
            {
                return child.gameObject;
            }
        }
        return null;
    }

    private void UpdateButtonText(GameObject button, Waypoint waypoint)
    {
        button.transform.Find("ID").GetComponent<Text>().text = waypoint.id.ToString();
        button.transform.Find("Location").GetComponent<Text>().text = $"{waypoint.location.latitude}, {waypoint.location.longitude}";
        button.transform.Find("Type").GetComponent<Text>().text = waypoint.type.ToString();
        button.transform.Find("Author").GetComponent<Text>().text = waypoint.author.ToString();
    }
}