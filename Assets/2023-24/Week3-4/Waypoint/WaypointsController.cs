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

        sh = GameObject.Find("ScrollObjects");
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
        Debug.Log("Deleted");
        List<Waypoint> deletedWaypoints = e.DeletedWaypoints; // Which waypoints were deleted (Look at their id's)
        // Update the UI to reflect the deleted waypoints
        foreach (Waypoint currentDeletedWapoint in deletedWaypoints)
        {
            if (idToButton.ContainsKey(currentDeletedWapoint.id))
            {
                sh.GetComponent<ScrollHandler>().HandleButtonDeletion(idToButton[currentDeletedWapoint.id]);
                idToButton.Remove(currentDeletedWapoint.id);
            }
        }
    }

    private void OnWaypointsEdited(WaypointsEditedEvent e)
    {
        Debug.Log("Edited");
        List<Waypoint> editedWaypoints = e.EditedWaypoints; // Which waypoints were edited (Look at their id's)
        // Update the UI to reflect the edited waypoints

        foreach (Waypoint edit in editedWaypoints) {
            if (idToButton.ContainsKey(edit.id)) {
                GameObject button = idToButton[edit.id];
                button.transform.Find("ID").gameObject.GetComponent<TextMeshPro>().text = "ID: " + edit.id.ToString();

                if (edit.type == 0) {
                    button.transform.Find("Type").gameObject.GetComponent<TextMeshPro>().text = "Type: Regular";
                } else if (edit.type == 1) {
                    button.transform.Find("Type").gameObject.GetComponent<TextMeshPro>().text = "Type: Danger";
                } else {
                    button.transform.Find("Type").gameObject.GetComponent<TextMeshPro>().text = "Type: Geo";
                }

            button.transform.Find("Location").gameObject.GetComponent<TextMeshPro>().text = "Location: " + "Latitude: " + edit.location.latitude.ToString() 
            + "Longitude: " + edit.location.longitude.ToString();
            //button.transform.Find("Location").gameObject.GetComponent<TextMeshPro>().latitude.text = "Latitude: " + edit.location.latitude.ToString();
            //button.transform.Find("Location").gameObject.GetComponent<TextMeshPro>().longitude.text = "Longitude: " + edit.location.longitude.ToString();
            button.transform.Find("Author").gameObject.GetComponent<TextMeshPro>().text = "Author: " + edit.author.ToString();

            }

            
        }
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
