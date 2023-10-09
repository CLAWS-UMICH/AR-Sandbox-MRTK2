using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChangedEvent
{
    public Screens Screen;

    public ScreenChangedEvent(Screens screen)
    {
        Screen = screen;
    }
}

public class CloseEvent
{
    public Screens Screen;

    public CloseEvent(Screens screen)
    {
        Screen = screen;
    }
}

// Event for letting us know GPS data was received from the server
public class UpdatedGPSEvent
{
    public UpdatedGPSEvent()
    {
        Debug.Log("GPS update event created");
    }

    public override string ToString()
    {
        return "<UpdatedGPSEvent>: new GPS msg";
    }
}

public class UpdatedGPSOriginEvent
{
    public UpdatedGPSOriginEvent()
    {
        Debug.Log("GPS origin updated");
    }

    public override string ToString()
    {
        return "<UpdatedGPSOriginEvent>: new GPS origin";
    }
}

public enum Direction { up, down }

public class ScrollEvent
{
    public Screens screen;
    public Direction direction;

    public ScrollEvent(Screens _screen, Direction _dir)
    {
        screen = _screen;
        direction = _dir;
        Debug.Log("Scrolling " + _screen.ToString() + " " + _dir.ToString());
    }

    public override string ToString()
    {
        return "<ScrollEvent>: " + screen.ToString() + " " + direction.ToString();
    }
}

public class VitalsUpdatedEvent
{
    public Vitals vitals { get; private set; }

    public VitalsUpdatedEvent(Vitals v)
    {
        vitals = v;
    }
    public override string ToString()
    {
        return "<VitalsUpdatedEvent>: vitals were updated";
    }
}

// Websockets
// --------------------------------------------------------------------------------

// Messaging
public class MessagesDeletedEvent
{
    public List<Message> DeletedMessages { get; private set; }

    public MessagesDeletedEvent(List<Message> deletedMessages)
    {
        DeletedMessages = deletedMessages;
    }
}

public class MessagesEditedEvent
{
    public List<Message> EditedMessages { get; private set; }

    public MessagesEditedEvent(List<Message> editedMessages)
    {
        EditedMessages = editedMessages;
    }
}

public class MessagesAddedEvent
{
    public List<Message> NewAddedMessages { get; private set; }

    public MessagesAddedEvent(List<Message> newAddedMessages)
    {
        NewAddedMessages = newAddedMessages;
    }
}

// Geosamples
public class GeosamplesDeletedEvent
{
    public List<Geosample> DeletedGeosamples { get; private set; }

    public GeosamplesDeletedEvent(List<Geosample> deletedGeosamples)
    {
        DeletedGeosamples = deletedGeosamples;
    }
}

public class GeosamplesEditedEvent
{
    public List<Geosample> EditedGeosamples { get; private set; }

    public GeosamplesEditedEvent(List<Geosample> editedGeosamples)
    {
        EditedGeosamples = editedGeosamples;
    }
}

public class GeosamplesAddedEvent
{
    public List<Geosample> NewAddedGeosamples { get; private set; }

    public GeosamplesAddedEvent(List<Geosample> newAddedGeosamples)
    {
        NewAddedGeosamples = newAddedGeosamples;
    }
}

// Waypoints
public class WaypointsDeletedEvent
{
    public List<Waypoint> DeletedWaypoints { get; private set; }

    public WaypointsDeletedEvent(List<Waypoint> deletedWaypoints)
    {
        DeletedWaypoints = deletedWaypoints;
    }
}

public class WaypointsEditedEvent
{
    public List<Waypoint> EditedWaypoints { get; private set; }

    public WaypointsEditedEvent(List<Waypoint> editedWaypoints)
    {
        EditedWaypoints = editedWaypoints;
    }
}

public class WaypointsAddedEvent
{
    public List<Waypoint> NewAddedWaypoints { get; private set; }

    public WaypointsAddedEvent(List<Waypoint> newAddedWaypoints)
    {
        NewAddedWaypoints = newAddedWaypoints;
    }
}

// Tasklist
public class TasksEditedEvent
{
    public List<TaskObj> EditedTasks { get; private set; }

    public TasksEditedEvent(List<TaskObj> editedTasks)
    {
        EditedTasks = editedTasks;
    }
}

public class TasksAddedEvent
{
    public List<TaskObj> NewAddedTasks { get; private set; }

    public TasksAddedEvent(List<TaskObj> newAddedTasks)
    {
        NewAddedTasks = newAddedTasks;
    }
}

public class TasksDeletedEvent
{
    public List<TaskObj> DeletedTasks { get; private set; }

    public TasksDeletedEvent(List<TaskObj> deletedTasks)
    {
        DeletedTasks = deletedTasks;
    }
}

// Mulitplayer
public class FellowAstronautDataChangeEvent
{
    public FellowAstronaut AstronautToChange { get; private set; }
    public List<string> ChangedParameters { get; private set; }

    public FellowAstronautDataChangeEvent(FellowAstronaut astronautToChange, List<string> changedParameters)
    {
        AstronautToChange = astronautToChange;
        ChangedParameters = changedParameters;
    }
}
