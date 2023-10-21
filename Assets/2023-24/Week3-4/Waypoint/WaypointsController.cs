using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WaypointsController : MonoBehaviour
{

    private Subscription<WaypointsDeletedEvent> waypointsDeletedEvent;
    private Subscription<WaypointsEditedEvent> waypointsEditedEvent;
    private Subscription<WaypointsAddedEvent> waypointsAddedEvent;

    private ScrollHandler scrollHandler;
    public GameObject waypointPrefab;
    TextMeshPro id;
    TextMeshPro location;
    TextMeshPro type;
    TextMeshPro author;
    

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        waypointsDeletedEvent = EventBus.Subscribe<WaypointsDeletedEvent>(OnWaypointsDeleted);
        waypointsEditedEvent = EventBus.Subscribe<WaypointsEditedEvent>(OnWaypointsEdited);
        waypointsAddedEvent = EventBus.Subscribe<WaypointsAddedEvent>(OnWaypointsAdded);
        scrollHandler = GetComponent<ScrollHandler>();
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
        //Debug.Log("Deleted");
        //List<Waypoint> deletedWaypoints = e.DeletedWaypoints; // Which waypoints were deleted (Look at their id's)
        // Update the UI to reflect the deleted waypoints
    }

    private void OnWaypointsEdited(WaypointsEditedEvent e)
    {
        //Debug.Log("Edited");
        //List<Waypoint> editedWaypoints = e.EditedWaypoints; // Which waypoints were edited (Look at their id's)
        // Update the UI to reflect the edited waypoints
    }

    private void OnWaypointsAdded(WaypointsAddedEvent e)
    {
        Debug.Log("Added");
        List<Waypoint> newAddedWaypoints = e.NewAddedWaypoints; // Which waypoints are new
        foreach (Waypoint currentAddedWaypoint in newAddedWaypoints)
        {
            //Push gameobjects to a list for the delete function
            GameObject newGameObject = Instantiate(waypointPrefab, scrollHandler.transform);
            if (newGameObject != null)
            {
                id = newGameObject.transform.Find("Id").gameObject.GetComponent<TextMeshPro>();
                location = newGameObject.transform.Find("Location").gameObject.GetComponent<TextMeshPro>();
                type = newGameObject.transform.Find("Type").gameObject.GetComponent<TextMeshPro>();
                author = newGameObject.transform.Find("Author").gameObject.GetComponent<TextMeshPro>();

                id.text = currentAddedWaypoint.id.ToString();
                location.text = currentAddedWaypoint.location.ToString();
                type.text = currentAddedWaypoint.type.ToString();
                author.text = currentAddedWaypoint.author.ToString();
            }

        }
        // Update the UI to reflect the new waypoints
    }
}
