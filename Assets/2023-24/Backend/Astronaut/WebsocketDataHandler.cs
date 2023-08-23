using UnityEngine;

public class WebsocketDataHandler : MonoBehaviour
{
    private Fake f;
    private WebSocketClient wsClient;

    public void Start()
    {
        wsClient = GetComponent<WebSocketClient>();
        f = GetComponent<Fake>();
    }
    public void HandleMessagingData(Messaging data, string use)
    {
        if (use == "GET")
        {
            Debug.Log("GET");
            string jsonData = JsonUtility.ToJson(f.astronautInstance.MessagingData);
            wsClient.SendJsonData(jsonData);
        } 
        else if (use == "POST") 
        {
            Debug.Log("POST");
            f.astronautInstance.MessagingData.AllMessages = data.AllMessages;
        } 
        else if (use == "DELETE")
        {
            Debug.Log("POST");
            f.astronautInstance.MessagingData.AllMessages = data.AllMessages;
        }
        else if (use == "PUT")
        {
            Debug.Log("POST");
            f.astronautInstance.MessagingData.AllMessages = data.AllMessages;
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }

    public void HandleVitalsData(Vitals data, string use)
    {
        if (use == "GET")
        {
            Debug.Log("GET");
            string jsonData = JsonUtility.ToJson(f.astronautInstance.VitalsData);
            wsClient.SendJsonData(jsonData);
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }

    public void HandleGeosamplesData(Geosamples data, string use)
    {
        if (use == "GET")
        {
            Debug.Log("GET");
            string jsonData = JsonUtility.ToJson(f.astronautInstance.GeosampleData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "POST")
        {
            Debug.Log("POST");
            f.astronautInstance.GeosampleData.AllGeosamples = data.AllGeosamples;
        }
        else if (use == "DELETE")
        {
            Debug.Log("DELETE");
            f.astronautInstance.GeosampleData.AllGeosamples = data.AllGeosamples;
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");
            f.astronautInstance.GeosampleData.AllGeosamples = data.AllGeosamples;
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }

    public void HandleWaypointsData(Waypoints data, string use)
    {
        if (use == "GET")
        {
            Debug.Log("GET");
            string jsonData = JsonUtility.ToJson(f.astronautInstance.WaypointData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "POST")
        {
            Debug.Log("POST");
            // Create Waypoint

            f.astronautInstance.WaypointData.AllWaypoints = data.AllWaypoints;
        }
        else if (use == "DELETE")
        {
            Debug.Log("DELETE");
            // Delete Waypoint

            f.astronautInstance.WaypointData.AllWaypoints = data.AllWaypoints;
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");
            // Edit Waypoint

            f.astronautInstance.WaypointData.AllWaypoints = data.AllWaypoints;
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }

    public void HandleTaskListData(TaskList data, string use)
    {
        if (use == "GET")
        {
            Debug.Log("GET");
            string jsonData = JsonUtility.ToJson(f.astronautInstance.TasklistData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "POST")
        {
            Debug.Log("POST");
            // Update tasklist

            f.astronautInstance.TasklistData.AllTasks = data.AllTasks;
        }
        else if (use == "DELETE")
        {
            Debug.Log("DELETE");
            // Update task(s) that was/were deleted

            f.astronautInstance.TasklistData.AllTasks = data.AllTasks;
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");
            // Update task(s) that was/were changed

            f.astronautInstance.TasklistData.AllTasks = data.AllTasks;

        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }

    public void HandleAlertsData(Alerts data, string use)
    {
        if (use == "GET")
        {
            Debug.Log("GET");

            string jsonData = JsonUtility.ToJson(f.astronautInstance.AlertData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "POST")
        {
            Debug.Log("POST");
            // Create Alert

            f.astronautInstance.AlertData.AllAlerts = data.AllAlerts;
        }
        else if (use == "DELETE")
        {
            Debug.Log("DELETE");
            // Update alerts that were deleted

            f.astronautInstance.AlertData.AllAlerts = data.AllAlerts;
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");
            // Update alerts that were changed

            f.astronautInstance.AlertData.AllAlerts = data.AllAlerts;
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }

    public void HandleAllBreadCrumbsData(AllBreadCrumbs data, string use)
    {
        if (use == "GET")
        {
            Debug.Log("GET");
            // Send new breadcrumb data

            string jsonData = JsonUtility.ToJson(f.astronautInstance.BreadCrumbData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "POST")
        {
            Debug.Log("POST");
            // Get new breadcrumb data

            f.astronautInstance.BreadCrumbData.AllCrumbs = data.AllCrumbs;
        }
        else if (use == "DELETE")
        {
            // Get new breadcrumb data

            f.astronautInstance.BreadCrumbData.AllCrumbs = data.AllCrumbs;
        }
        else if (use == "PUT")
        {
            // Update the breadcrumbs that were changed

            f.astronautInstance.BreadCrumbData.AllCrumbs = data.AllCrumbs;
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }

    public void HandleLocationData(Location data, string use)
    {
        if (use == "GET")
        {
            Debug.Log("GET");

            string jsonData = JsonUtility.ToJson(f.astronautInstance.location);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "POST")
        {
            Debug.Log("POST");
            // Update location

            f.astronautInstance.location = data;
        }
        else if (use == "DELETE")
        {
            Debug.Log("DELETE");
            // Update location

            f.astronautInstance.location = data;
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");
            // Update location

            f.astronautInstance.location = data;
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }
}
