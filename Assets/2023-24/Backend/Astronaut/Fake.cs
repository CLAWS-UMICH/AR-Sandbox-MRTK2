using System.Collections.Generic;
using UnityEngine;

public class Fake : MonoBehaviour
{

    public Astronaut astronautInstance = new Astronaut();
    // Start is called before the first frame update
    void Start()
    {
        astronautInstance.AstronautId = 1;

        /*// Create fake Messaging data
        astronautInstance.MessagingData = new Messaging();

        // Create fake Vitals data
        astronautInstance.VitalsData = new Vitals();
        astronautInstance.VitalsData.heart_rate = 80;
        astronautInstance.VitalsData.oxygen = 95.5f;
        astronautInstance.VitalsData.suit_temp = 28.0f;

        // Create fake Geosamples data
        astronautInstance.GeosampleData = new Geosamples();
        Geosample fakeGeosample = new Geosample { id = 1, time = "2023-08-24", author = 2 };
        astronautInstance.GeosampleData.AllGeosamples.Add(fakeGeosample);

        // Create fake Waypoints data
        astronautInstance.WaypointData = new Waypoints();
        Waypoint fakeWaypoint = new Waypoint { id = 1, type = 0, author = 1 };
        astronautInstance.WaypointData.AllWaypoints.Add(fakeWaypoint);

        // Create fake Tasklist data
        astronautInstance.TasklistData = new TaskList();
        TaskObj fakeTask = new TaskObj { status = 0, title = "Explore", description = "Collect samples", id = 1, shared_with = 2 };
        astronautInstance.TasklistData.AllTasks.Add(fakeTask);

        // Create fake Alerts data
        astronautInstance.AlertData = new Alerts();
        AlertObj fakeAlert = new AlertObj { id_in_danger = 1, vital = "heart_rate", vital_val = 90.0f };
        astronautInstance.AlertData.AllAlerts.Add(fakeAlert);

        // Create fake BreadCrumbs data
        astronautInstance.BreadCrumbData = new AllBreadCrumbs();
        Breadcrumb breadcrumb1 = new Breadcrumb { location = new Location { latitude = 37.7751, longitude = -122.4196 }, type = BreadCrumbType.navigation };
        Breadcrumb breadcrumb2 = new Breadcrumb { location = new Location { latitude = 37.7752, longitude = -122.4197 }, type = BreadCrumbType.backtracking };
        astronautInstance.BreadCrumbData.AllCrumbs.Add(breadcrumb1);
        astronautInstance.BreadCrumbData.AllCrumbs.Add(breadcrumb2);*/

        // Set other properties
        astronautInstance.location = new Location { latitude = 37.7749, longitude = -122.4194 };
        astronautInstance.currently_navigating = false;
        astronautInstance.inDanger = false;
        astronautInstance.color = "Blue";
    }

}
