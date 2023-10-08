# Waypoint Python Server for webosckets. It send 3 waypoints at first and then deletes 1, then loops again and again.
# Steps:
# Run this file in VSCode and AFTER run your unity scene
# Update buttons UI to these waypoints using the scroll handler provided
# Use the event system to subscribe

import asyncio
import websockets # If this gives a warning/error, open command line and do 'pip install websockets'
import json

async def send_data_initial(websocket):
    data = {
        "id" : "1",
        "type": "Waypoints",
        "use": "PUT",
        "data": {
            "AllWaypoints": [
                {
                    "id": 1,
                    "location": {
                        "latitude": 34.2234234,
                        "longitude": 45.345345345
                    },
                    "type": 1,
                    "author": 1,
                },
                {
                    "id": 2,
                    "location": {
                        "latitude": 34.1234567,
                        "longitude": 45.6789012
                    },
                    "type": 0,
                    "author": 2,
                },
                {
                    "id": 3,
                    "location": {
                        "latitude": 34.36343,
                        "longitude": 45.74567
                    },
                    "type": 2,
                    "author": 1,
                }
                # Add more waypoints as needed
            ]
        }
    }

    # Convert the data to a JSON string
    message = json.dumps(data)

    # Send the JSON message to the connected client (Unity)
    await websocket.send(message)

async def send_data_deleted(websocket):
    data = {
        "id" : "1",
        "type": "Waypoints",
        "use": "PUT",
        "data": {
            "AllWaypoints": [
                {
                    "id": 1,
                    "location": {
                        "latitude": 34.2234234,
                        "longitude": 45.345345345
                    },
                    "type": 1,
                    "author": 1,
                },
                {
                    "id": 3,
                    "location": {
                        "latitude": 34.36343,
                        "longitude": 45.74567
                    },
                    "type": 2,
                    "author": 1,
                }
                # Add more waypoints as needed
            ]
        }
    }

    # Convert the data to a JSON string
    message = json.dumps(data)

    # Send the JSON message to the connected client (Unity)
    await websocket.send(message)

async def handle_client(websocket, path):
    try:
        while True:
            await send_data_initial(websocket)
            await asyncio.sleep(5)
            await send_data_deleted(websocket)
            await asyncio.sleep(5)
    except websockets.exceptions.ConnectionClosed:
        pass

start_server = websockets.serve(handle_client, "localhost", 8080)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()
