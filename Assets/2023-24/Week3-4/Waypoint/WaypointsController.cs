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
    private GameObject sh;
    public GameObject waypointPrefab;
    TextMeshPro id;
    TextMeshPro location;
    TextMeshPro type;
    TextMeshPro author;
    private Dictionary<int, GameObject> idToButton = new Dictionary<int, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        id = waypointPrefab.transform.Find("Id").gameObject.GetComponent<TextMeshPro>();
        location = waypointPrefab.transform.Find("Location").gameObject.GetComponent<TextMeshPro>();
        type = waypointPrefab.transform.Find("Type").gameObject.GetComponent<TextMeshPro>();
        author = waypointPrefab.transform.Find("Author").gameObject.GetComponent<TextMeshPro>();
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
            id.text = currentAddedWaypoint.id.ToString();
            location.text = currentAddedWaypoint.location.ToString();
            type.text = currentAddedWaypoint.type.ToString();
            author.text = currentAddedWaypoint.author.ToString();
   
            GameObject newButton = sh.GetComponent<ScrollHandler>().HandleAddingButton(waypointPrefab);
            idToButton.Add(currentAddedWaypoint.id, newButton);
        }

        // Update the UI to reflect the new waypoints
    }
}
