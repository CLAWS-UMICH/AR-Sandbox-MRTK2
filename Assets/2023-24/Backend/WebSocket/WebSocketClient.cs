using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;

public class WebSocketClient : MonoBehaviour
{
    private WebSocket ws;
    public Fake f;

    private void Start()
    {
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
        Debug.Log("test1");
        // Deserialize the JSON into JsonMessage class
        JsonMessage jsonMessage = JsonUtility.FromJson<JsonMessage>(jsonData);

        // Determine the type of data
        string messageType = jsonMessage.type;

        switch (messageType)
        {
            case "Location":
                TestLocation test = JsonUtility.FromJson<TestLocation>(jsonData);
                HandleLocationData(test.data);
                break;
            // Handle other message types similarly
            default:
                Debug.LogWarning("Unknown message type: " + messageType);
                break;
        }
    }

    private void HandleLocationData(Location locationData)
    {
        double latitude = locationData.latitude;
        double longitude = locationData.longitude;

        Debug.Log("Received Location:");
        Debug.Log("Latitude: " + latitude);
        Debug.Log("Longitude: " + longitude);
    }


}

[Serializable]
public class JsonMessage
{
    public string type;
}


[Serializable]
public class TestLocation
{
    public Location data;
}
