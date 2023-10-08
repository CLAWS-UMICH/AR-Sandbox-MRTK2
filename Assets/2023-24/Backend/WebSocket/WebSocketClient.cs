using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;

public class WebSocketClient : MonoBehaviour
{
    private WebSocket ws;
    private Fake f;
    private WebsocketDataHandler dataHandler;

    private void Start()
    {
        f = GetComponent<Fake>();
        dataHandler = GetComponent<WebsocketDataHandler>();
        ws = new WebSocket("ws://localhost:8080");
        ws.OnMessage += OnWebSocketMessage;
        ws.Connect();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessage("Location", f.astronautInstance.location);
        }
    }

    private void OnDestroy()
    {
        if (ws != null && ws.IsAlive)
        {
            ws.Close();
        }
    }

    private void OnWebSocketMessage(object sender, MessageEventArgs e)
    {
        if (e.Data != null)
        {
            // Handle incoming JSON messages
            string receivedData = e.Data;
            Debug.Log("Received WebSocket message: " + receivedData);
            try
            {
                HandleJsonMessage(e.Data);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error handling JSON message: " + ex.Message);
            }
        }
        else
        {
            Debug.LogWarning("Received empty JSON data.");
        }
    }

    private void HandleJsonMessage(string jsonData)
    {
        // Deserialize the JSON into JsonMessage class
        JsonMessage jsonMessage = JsonUtility.FromJson<JsonMessage>(jsonData);

        // Determine the type of data
        string messageType = jsonMessage.type;
        string messageUse = jsonMessage.use;

        switch (messageType)
        {
            case "Messaging":
                MessagingData messageData = JsonUtility.FromJson<MessagingData>(jsonData);
                dataHandler.HandleMessagingData(messageData.data, messageUse);
                break;
            case "Vitals":
                VitalsData vitalsData = JsonUtility.FromJson<VitalsData>(jsonData);
                dataHandler.HandleVitalsData(vitalsData.data, messageUse);
                break;
            case "Geosamples":
                GeosamplesData geoData = JsonUtility.FromJson<GeosamplesData>(jsonData);
                dataHandler.HandleGeosamplesData(geoData.data, messageUse);
                break;
            case "Waypoints":
                WaypointsData waypointsData = JsonUtility.FromJson<WaypointsData>(jsonData);
                dataHandler.HandleWaypointsData(waypointsData.data, messageUse);
                break;
            case "TaskList":
                TaskListData taskListData = JsonUtility.FromJson<TaskListData>(jsonData);
                dataHandler.HandleTaskListData(taskListData.data, messageUse);
                break;
            case "Alerts":
                AlertsData alertsData = JsonUtility.FromJson<AlertsData>(jsonData);
                dataHandler.HandleAlertsData(alertsData.data, messageUse);
                break;
            case "AllBreadCrumbs":
                AllBreadCrumbsData breadcrumbsData = JsonUtility.FromJson<AllBreadCrumbsData>(jsonData);
                dataHandler.HandleAllBreadCrumbsData(breadcrumbsData.data, messageUse);
                break;
            case "Location":
                LocationData locationData = JsonUtility.FromJson<LocationData>(jsonData);
                dataHandler.HandleLocationData(locationData.data, messageUse);
                break;
            case "Multiplayer":
                MultiplayerData multiData = JsonUtility.FromJson<MultiplayerData>(jsonData);
                dataHandler.HandleMultiplayerData(multiData.data, messageUse, multiData.id, multiData.dataToChange);
                break;
            // Handle other message types similarly
            default:
                Debug.LogWarning("Unknown message type: " + messageType);
                break;
        }
    }

    public void SendJsonData(string jsonData)
    {
        if (ws != null && ws.IsAlive)
        {
            ws.Send(jsonData);
        }
    }
}

[Serializable]
public class JsonMessage
{
    public string type;
    public string use;
}

[Serializable]
public class MessagingData
{
    public Messaging data;
    public int AstronautId;
}

[Serializable]
public class VitalsData
{
    public Vitals data;
    public int AstronautId;
}

[Serializable]
public class GeosamplesData
{
    public Geosamples data;
    public int AstronautId;
}

[Serializable]
public class WaypointsData
{
    public Waypoints data;
    public int AstronautId;
}

[Serializable]
public class TaskListData
{
    public TaskList data;
    public int AstronautId;
}

[Serializable]
public class AlertsData
{
    public Alerts data;
    public int AstronautId;
}

[Serializable]
public class AllBreadCrumbsData
{
    public AllBreadCrumbs data;
    public int AstronautId;
}

[Serializable]
public class LocationData
{
    public Location data;
    public int AstronautId;
}

[Serializable]
public class MultiplayerData
{
    public FellowAstronauts data;
    public int id;
    public List<string> dataToChange;
    public int AstronautId;
}
