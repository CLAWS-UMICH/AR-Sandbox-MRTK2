using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    private WebSocket ws;

    private void Start()
    {
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sent to server");
            ws.Send("Test Message from Unity");
        }
    }

    private void OnDestroy()
    {
        if (ws != null && ws.IsAlive)
        {
            ws.Close();
        }
    }

    public void SendMessage()
    {
        Debug.Log("Sent to server");
        ws.Send("Test Message from Unity");
    }
}
