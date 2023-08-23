using System.Collections.Generic;
using UnityEngine;

public class Fake : MonoBehaviour
{

    public Astronaut astronautInstance = new Astronaut();
    // Start is called before the first frame update
    void Start()
    {

        // Set values for the properties of the Astronaut instance
        astronautInstance.AstronautId = 1;
        astronautInstance.MessagingData = new Messaging();
        astronautInstance.VitalsData = new Vitals();
        astronautInstance.GeosampleData = new Geosample();
        astronautInstance.WaypointData = new Waypoint();
        astronautInstance.TasklistData = new Tasklist();
        astronautInstance.AlertData = new Alert();
        astronautInstance.BreadCrumbs = new List<Breadcrumb>();
        astronautInstance.location = new Location();
        astronautInstance.currently_navigating = false;
        astronautInstance.inDanger = false;
        astronautInstance.color = "Blue";

        // Location
        astronautInstance.location.latitude = 37.7749;
        astronautInstance.location.longitude = -122.4194;

        Debug.Log("Astronaut ID: " + astronautInstance.AstronautId);
        Debug.Log("Astronaut Color: " + astronautInstance.color);
    }

}
