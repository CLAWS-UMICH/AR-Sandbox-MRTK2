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

            // Create a new CombinedData instance
            MessagingData combinedData = new MessagingData
            {
                data = f.astronautInstance.MessagingData,
                AstronautId = f.astronautInstance.AstronautId
            };

            // Convert the combined data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(combinedData);

            wsClient.SendJsonData(jsonData);
        } 
        else if (use == "PUT")
        {
            Debug.Log("PUT");

            // Get the current list of messages from the instance
            List<Message> currentMessages = f.astronautInstance.MessagingData.AllMessages;

            // Get the new list of messages from the data parameter
            List<Message> newMessages = data.AllMessages;

            List<Message> deletedMessages = new List<Message>();
            List<Message> editedMessages = new List<Message>();
            List<Message> newAddedMessages = new List<Message>();

            foreach (Message currentMessage in currentMessages)
            {
                bool messageFound = false;

                foreach (Message newMessage in newMessages)
                {
                    if (currentMessage.id == newMessage.id)
                    {
                        messageFound = true;
                        if (!currentMessage.Equals(newMessage))
                        {
                            editedMessages.Add(newMessage);
                        }
                        break;
                    }
                }

                if (!messageFound)
                {
                    deletedMessages.Add(currentMessage);
                }
            }

            foreach (Message newMessage in newMessages)
            {
                bool isNew = true;

                foreach (Message currentMessage in currentMessages)
                {
                    if (currentMessage.id == newMessage.id)
                    {
                        isNew = false;
                        break;
                    }
                }

                if (isNew)
                {
                    newAddedMessages.Add(newMessage);
                }
            }

            // Publish events for each scenario
            if (deletedMessages.Count > 0)
            {
                EventBus.Publish(new MessagesDeletedEvent(deletedMessages));
            }

            if (editedMessages.Count > 0)
            {
                EventBus.Publish(new MessagesEditedEvent(editedMessages));
            }

            if (newAddedMessages.Count > 0)
            {
                EventBus.Publish(new MessagesAddedEvent(newAddedMessages));
            }

            // Update the list of messages with the new data
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

            // Create a new CombinedData instance
            VitalsData combinedData = new VitalsData
            {
                data = f.astronautInstance.VitalsData,
                AstronautId = f.astronautInstance.AstronautId
            };

            // Convert the vitals data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(combinedData);
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

            // Create a new CombinedData instance
            GeosamplesData combinedData = new GeosamplesData
            {
                data = f.astronautInstance.GeosampleData,
                AstronautId = f.astronautInstance.AstronautId
            };

            // Convert the vitals data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(combinedData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");

            Debug.Log("PUT");

            // Get the current list of geosamples from the instance
            List<Geosample> currentGeosamples = f.astronautInstance.GeosampleData.AllGeosamples;

            // Get the new list of geosamples from the data parameter
            List<Geosample> newGeosamples = data.AllGeosamples;

            List<Geosample> deletedGeosamples = new List<Geosample>();
            List<Geosample> editedGeosamples = new List<Geosample>();
            List<Geosample> newAddedGeosamples = new List<Geosample>();

            foreach (Geosample currentSample in currentGeosamples)
            {
                bool sampleFound = false;

                foreach (Geosample newSample in newGeosamples)
                {
                    if (currentSample.id == newSample.id)
                    {
                        sampleFound = true;
                        if (!currentSample.Equals(newSample))
                        {
                            editedGeosamples.Add(newSample);
                        }
                        break;
                    }
                }

                if (!sampleFound)
                {
                    deletedGeosamples.Add(currentSample);
                }
            }

            foreach (Geosample newSample in newGeosamples)
            {
                bool isNew = true;

                foreach (Geosample currentSample in currentGeosamples)
                {
                    if (currentSample.id == newSample.id)
                    {
                        isNew = false;
                        break;
                    }
                }

                if (isNew)
                {
                    newAddedGeosamples.Add(newSample);
                }
            }

            // Publish events for each scenario
            if (deletedGeosamples.Count > 0)
            {
                EventBus.Publish(new GeosamplesDeletedEvent(deletedGeosamples));
            }

            if (editedGeosamples.Count > 0)
            {
                EventBus.Publish(new GeosamplesEditedEvent(editedGeosamples));
            }

            if (newAddedGeosamples.Count > 0)
            {
                EventBus.Publish(new GeosamplesAddedEvent(newAddedGeosamples));
            }

            // Update the list of geosamples with the new data
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

            // Create a new CombinedData instance
            WaypointsData combinedData = new WaypointsData
            {
                data = f.astronautInstance.WaypointData,
                AstronautId = f.astronautInstance.AstronautId
            };

            // Convert the vitals data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(combinedData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");

            // Get the current list of waypoints from the instance
            List<Waypoint> currentWaypoints = f.astronautInstance.WaypointData.AllWaypoints;

            // Get the new list of waypoints from the data parameter
            List<Waypoint> newWaypoints = data.AllWaypoints;

            List<Waypoint> deletedWaypoints = new List<Waypoint>();
            List<Waypoint> editedWaypoints = new List<Waypoint>();
            List<Waypoint> newAddedWaypoints = new List<Waypoint>();

            foreach (Waypoint currentWaypoint in currentWaypoints)
            {
                bool waypointFound = false;

                foreach (Waypoint newWaypoint in newWaypoints)
                {
                    if (currentWaypoint.id == newWaypoint.id)
                    {
                        waypointFound = true;
                        if (!currentWaypoint.Equals(newWaypoint))
                        {
                            editedWaypoints.Add(newWaypoint);
                        }
                        break;
                    }
                }

                if (!waypointFound)
                {
                    deletedWaypoints.Add(currentWaypoint);
                }
            }

            foreach (Waypoint newWaypoint in newWaypoints)
            {
                bool isNew = true;

                foreach (Waypoint currentWaypoint in currentWaypoints)
                {
                    if (currentWaypoint.id == newWaypoint.id)
                    {
                        isNew = false;
                        break;
                    }
                }

                if (isNew)
                {
                    newAddedWaypoints.Add(newWaypoint);
                }
            }

            // Publish events for each scenario
            if (deletedWaypoints.Count > 0)
            {
                EventBus.Publish(new WaypointsDeletedEvent(deletedWaypoints));
            }

            if (editedWaypoints.Count > 0)
            {
                EventBus.Publish(new WaypointsEditedEvent(editedWaypoints));
            }

            if (newAddedWaypoints.Count > 0)
            {
                EventBus.Publish(new WaypointsAddedEvent(newAddedWaypoints));
            }

            // Update the list of waypoints with the new data
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

            // Create a new CombinedData instance
            TaskListData combinedData = new TaskListData
            {
                data = f.astronautInstance.TasklistData,
                AstronautId = f.astronautInstance.AstronautId
            };

            // Convert the vitals data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(combinedData);
            wsClient.SendJsonData(jsonData);
        }
        else if (use == "PUT")
        {
            Debug.Log("PUT");

            // Get the current list of tasks from the instance
            List<TaskObj> currentTasks = f.astronautInstance.TasklistData.AllTasks;

            // Get the new list of tasks from the data parameter
            List<TaskObj> newTasks = data.AllTasks;

            List<TaskObj> deletedTasks = new List<TaskObj>();
            List<TaskObj> editedTasks = new List<TaskObj>();
            List<TaskObj> newAddedTasks = new List<TaskObj>();

            foreach (TaskObj currentTask in currentTasks)
            {
                bool taskFound = false;

                foreach (TaskObj newTask in newTasks)
                {
                    if (currentTask.id == newTask.id)
                    {
                        taskFound = true;
                        if (!currentTask.Equals(newTask))
                        {
                            editedTasks.Add(newTask);
                        }
                        break;
                    }
                }

                if (!taskFound)
                {
                    deletedTasks.Add(currentTask);
                }
            }

            foreach (TaskObj newTask in newTasks)
            {
                bool isNew = true;

                foreach (TaskObj currentTask in currentTasks)
                {
                    if (currentTask.id == newTask.id)
                    {
                        isNew = false;
                        break;
                    }
                }

                if (isNew)
                {
                    newAddedTasks.Add(newTask);
                }
            }

            // Publish events for each scenario
            if (deletedTasks.Count > 0)
            {
                EventBus.Publish(new TasksDeletedEvent(deletedTasks));
            }

            if (editedTasks.Count > 0)
            {
                EventBus.Publish(new TasksEditedEvent(editedTasks));
            }

            if (newAddedTasks.Count > 0)
            {
                EventBus.Publish(new TasksAddedEvent(newAddedTasks));
            }

            // Update the list of tasks with the new data
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

            // Create a new CombinedData instance
            AlertsData combinedData = new AlertsData
            {
                data = f.astronautInstance.AlertData,
                AstronautId = f.astronautInstance.AstronautId
            };

            // Convert the vitals data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(combinedData);

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

            // Create a new CombinedData instance
            AllBreadCrumbsData combinedData = new AllBreadCrumbsData
            {
                data = f.astronautInstance.BreadCrumbData,
                AstronautId = f.astronautInstance.AstronautId
            };

            // Convert the vitals data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(combinedData);
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

            // Create a new CombinedData instance
            LocationData combinedData = new LocationData
            {
                data = f.astronautInstance.location,
                AstronautId = f.astronautInstance.AstronautId
            };

            // Convert the vitals data to JSON format and send to WebSocket client
            string jsonData = JsonUtility.ToJson(combinedData);

            wsClient.SendJsonData(jsonData);
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
                if (a.AstronautID == id)
                {
                    astronautToChangeIndex = i;
                    astronautToChange = a;
                }
            }

            if (astronautToChange != null)
            {
                List<string> changedParameters = new List<string>();

                foreach (string change in changes)
                {
                    if (change == "location" || change == "vitals" || change == "breadcrumbs" || change == "navigating")
                    {
                        changedParameters.Add(change);
                    }
                    else
                    {
                        Debug.Log("Unknown change to be made");
                    }
                }

                if (changedParameters.Count > 0)
                {
                    // Publish an event indicating the changes to fellow astronaut's data
                    EventBus.Publish(new FellowAstronautDataChangeEvent(astronautToChange, changedParameters));
                }

                // Update the fellow astronaut's data with the new data
                f.astronautInstance.FellowAstronautsData.AllFellowAstronauts = data.AllFellowAstronauts;
            }
        }
        else
        {
            Debug.Log("Invalid use case from server");
        }
    }
}
