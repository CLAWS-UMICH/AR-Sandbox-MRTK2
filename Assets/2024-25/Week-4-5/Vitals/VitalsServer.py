# Waypoint Python Server for webosckets. It send 3 waypoints at first and then deletes 1, then loops again and again.
# Steps:
# Run this file in VSCode and AFTER run your unity scene
# Update buttons UI to these waypoints using the scroll handler provided
# Use the event system to subscribe

import asyncio
import websockets
import json
import random  # Import the random module to generate random values
print("executed")

async def send_random_data(websocket):
    while True:
        # Create a JSON object with random values
        print("created")
        data = {
            "id": "1",
            "type": "Vitals",
            "use": "PUT",
            "data": {
                "heart_rate": random.randint(0, 100),
                "oxygen": random.randint(0, 100),
                "suit_temp": random.randint(0, 100),
                "blood_pressure": random.randint(0, 100),
            }
        }

        # Convert the data to a JSON string
        message = json.dumps(data)
        print("sending vitals")

        # Send the JSON message to the connected client (Unity)
        await websocket.send(message)
        print("message sent")

        # Wait for one second before sending the next JSON
        await asyncio.sleep(3)
        

async def handle_client(websocket, path):
    try:
        await send_random_data(websocket)
    except websockets.exceptions.ConnectionClosed:
        print("closed")
        pass

start_server = websockets.serve(handle_client, "localhost", 8080)
print("server made")

asyncio.get_event_loop().run_until_complete(start_server)
print("server running")
asyncio.get_event_loop().run_forever()
