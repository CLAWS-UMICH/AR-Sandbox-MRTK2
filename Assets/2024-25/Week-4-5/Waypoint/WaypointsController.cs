using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{

    private Subscription<WaypointsDeletedEvent> waypointsDeletedEvent;
    private Subscription<WaypointsEditedEvent> waypointsEditedEvent;
    private Subscription<WaypointsAddedEvent> waypointsAddedEvent;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        waypointsDeletedEvent = EventBus.Subscribe<WaypointsDeletedEvent>(OnWaypointsDeleted);
        waypointsEditedEvent = EventBus.Subscribe<WaypointsEditedEvent>(OnWaypointsEdited);
        waypointsAddedEvent = EventBus.Subscribe<WaypointsAddedEvent>(OnWaypointsAdded);
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
        List<Waypoint> deletedWaypoints = e.DeletedWaypoints; // Which waypoints were deleted (Look at their id's)
        // Update the UI to reflect the deleted waypoints
    }

    private void OnWaypointsEdited(WaypointsEditedEvent e)
    {
        //Debug.Log("Edited");
        List<Waypoint> editedWaypoints = e.EditedWaypoints; // Which waypoints were edited (Look at their id's)
        // Update the UI to reflect the edited waypoints
    }

    private void OnWaypointsAdded(WaypointsAddedEvent e)
    {
        //Debug.Log("Added");
        List<Waypoint> newAddedWaypoints = e.NewAddedWaypoints; // Which waypoints are new
        // Update the UI to reflect the new waypoints
    }
}