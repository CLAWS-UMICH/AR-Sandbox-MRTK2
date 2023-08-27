using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

            // Convert the messaging data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(f.astronautInstance.MessagingData);
            
            wsClient.SendJsonData(jsonData);
        } 
        else if (use == "PUT")
        {
            Debug.Log("PUT");

            // Get the current list of messages from the instance
            List<Message> currentMessages = f.astronautInstance.MessagingData.AllMessages;

            // Get the new list of messages from the data parameter
            List<Message> newMessages = data.AllMessages;

            // Iterate through each new message and check if its ID is in current messages
            foreach (Message newMessage in newMessages)
            {
                bool isNew = true;

                // Check if the new message's ID is already in the current messages
                foreach (Message currentMessage in currentMessages)
                {
                    if (currentMessage.id == newMessage.id)
                    {
                        isNew = false;
                        // Compare attributes to check if it's different
                        if (!currentMessage.Equals(newMessage))
                        {
                            // TODO: Additional logic to handle the change

                        }
                        break;
                    }
                }

                // If the new message's ID was not found in the current messages, add it
                if (isNew)
                {
                    // TODO: Add new message to the messages

                    f.astronautInstance.MessagingData.AllMessages.Add(newMessage);
                }
            }
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

            // Convert the vitals data to JSON format and send to WebSocket client
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

            // Convert the geosample data to JSON format and send to the WebSocket client
            string jsonData = JsonUtility.ToJson(f.astronautInstance.GeosampleData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");

            // Get the current list of geosamples from the instance
            List<Geosample> currentGeosamples = f.astronautInstance.GeosampleData.AllGeosamples;

            // Get the new list of geosamples from the data parameter
            List<Geosample> newGeosamples = data.AllGeosamples;

            // Iterate through each new geosample and check if its ID is in current geosamples
            foreach (Geosample newSample in newGeosamples)
            {
                bool isNew = true;

                // Check if the new geosample's ID is already in the current geosamples
                foreach (Geosample currentSample in currentGeosamples)
                {
                    if (currentSample.id == newSample.id)
                    {
                        isNew = false;
                        // Compare attributes to check if it's different
                        if (!currentSample.Equals(newSample))
                        {
                            // TODO: Additional logic to handle the change

                        }
                        break;
                    }
                }

                // If the new geosample's ID was not found in the current geosamples, add it
                if (isNew)
                {
                    // TODO: Add new Geosample to the geosamples

                }
            }

            // Update the list of geosamples with the new data
            f.astronautInstance.GeosampleData.AllGeosamples = currentGeosamples;
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
        else if (use == "PUT")
        {
            // Get the current list of waypoints from the instance
            List<Waypoint> currentWaypoints = f.astronautInstance.WaypointData.AllWaypoints;

            // Get the new list of waypoints from the data parameter
            List<Waypoint> newWaypoints = data.AllWaypoints;

            // Iterate through each new waypoint and check if its ID is in current waypoints
            foreach (Waypoint newWaypoint in newWaypoints)
            {
                bool isNew = true;

                // Check if the new waypoint's ID is already in the current waypoints
                foreach (Waypoint currentWaypoint in currentWaypoints)
                {
                    if (currentWaypoint.id == newWaypoint.id)
                    {
                        isNew = false;
                        // Compare attributes to check if it's different
                        if (!currentWaypoint.Equals(newWaypoint))
                        {
                            // TODO: Additional logic to handle the change

                        }
                        break;
                    }
                }

                // If the new waypoint's ID was not found in the current waypoints, add it
                if (isNew)
                {
                    // TODO: Add new Waypoint to the waypoints

                }
            }

            // Update the list of waypoints with the new data
            f.astronautInstance.WaypointData.AllWaypoints = newWaypoints;
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
        else if (use == "PUT")
        {
            Debug.Log("PUT");

            // Get the current list of tasks from the instance
            List<TaskObj> currentTasks = f.astronautInstance.TasklistData.AllTasks;

            // Get the new list of tasks from the data parameter
            List<TaskObj> newTasks = data.AllTasks;

            // Iterate through each new task and check if its ID is in current tasks
            foreach (TaskObj newTask in newTasks)
            {
                bool isFound = false;

                // Find the corresponding task in current tasks by ID
                foreach (TaskObj currentTask in currentTasks)
                {
                    if (currentTask.id == newTask.id)
                    {
                        isFound = true;
                        // Compare attributes to check if it's different
                        if (!currentTask.Equals(newTask))
                        {
                            // TODO: Additional logic to handle the change

                        }
                        break;
                    }
                }

                // If the new task's ID was not found in the current tasks, add it
                if (!isFound)
                {
                    // TODO: Add new Task to the tasks

                }
            }

            // Update the list of tasks with the new data
            f.astronautInstance.TasklistData.AllTasks = currentTasks;

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
        else if (use == "PUT")
        {
            Debug.Log("PUT");

            // Convert the alerts data to JSON format and send it to WebSocket
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

            // Convert the breadcrumb data to JSON format and send it to WebSocket
            string jsonData = JsonUtility.ToJson(f.astronautInstance.BreadCrumbData);
            wsClient.SendJsonData(jsonData);
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

            // Convert the location data to JSON format and send it to WebSocket
            string jsonData = JsonUtility.ToJson(f.astronautInstance.location);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");
            // TODO: Update astronaut's location

            // Update astranaut's class' location
            f.astronautInstance.location = data;
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }

    public void HandleMultiplayerData(FellowAstronauts data, string use, int id, List<string> changes)
    {
        if (use == "PUT")
        {
            Debug.Log("PUT");

            // Initialize variables to track changes
            FellowAstronaut astronautToChange = null;
            int astronautToChangeIndex = -1;

            // Iterate through the list of fellow astronauts to find the one with the given ID
            for (int i = 0; i < f.astronautInstance.FellowAstronautsData.AllFellowAstronauts.Count; i++)
            {
                FellowAstronaut a = f.astronautInstance.FellowAstronautsData.AllFellowAstronauts[i];
                if (a.id == id)
                {
                    astronautToChangeIndex = i;
                    astronautToChange = a;
                }
            }

            if (astronautToChange != null)
            {
                // Edit based on the change and index
                // TODO: Implement the logic to update the other astranaut data
                // Use: astronautToChange and astronautToChangeIndex and changes

                foreach (string change in changes)
                {
                    if (change ==  "location")
                    {
                        // TODO: Update fellow astronaut's location
                        // Use: astronautToChange.location
                    }
                    else if (change == "vitals")
                    {
                        // TODO: Update fellow astronaut's vitals
                        // Use: astronautToChange.vitals
                    }
                    else if (change == "breadcrumbs")
                    {
                        // TODO: Update fellow astronaut's breadcrumbs
                        // Use: astronautToChange.bread_crumbs
                    } 
                    else if (change == "navigating")
                    {
                        // TODO: Update Update fellow astronaut's navigating mode
                        // Use: astronautToChange.navigating
                    }
                    else
                    {
                        Debug.Log("Unknown change to be made");
                    }
                }

                // Update the entire fellow astronauts data with the new data
                f.astronautInstance.FellowAstronautsData = data;
            }
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }
}
