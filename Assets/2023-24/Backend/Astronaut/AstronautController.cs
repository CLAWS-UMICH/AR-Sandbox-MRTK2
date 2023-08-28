using UnityEngine;
using System.Collections.Generic;

// Messaging
[System.Serializable]
public class Messaging
{
    public List<Message> AllMessages = new List<Message>();
}

[System.Serializable]
public class Message
{
    public int id;
    public int sent_to;
    public string message;
    public int from;
}

// Vitals
[System.Serializable]
public class Vitals
{
    public int heart_rate;
    public float oxygen;
    public float suit_temp;
    // ...
}

// Geosamples
[System.Serializable]
public class Geosamples
{
    public List<Geosample> AllGeosamples = new List<Geosample>();
}

[System.Serializable]
public class Geosample
{
    public int id;
    public SpecData spec_data;
    public string time;
    public Location location;
    public int author;
}

[System.Serializable]
public class SpecData
{
    public int rock_example_data;
}

// Waypoints
[System.Serializable]
public class Waypoints
{
    public List<Waypoint> AllWaypoints = new List<Waypoint>();
}

[System.Serializable]
public class Waypoint
{
    public int id;
    public Location location;
    public WaypointType type;
    public int author;
}

public enum WaypointType
{
    regular,
    danger,
    geo
}

// Tasklists
[System.Serializable]
public class TaskList
{
    public List<TaskObj> AllTasks = new List<TaskObj>();
}

[System.Serializable]
public class TaskObj
{
    public TaskStatus status;
    public string title;
    public string description;
    public int id;
    public int shared_with;
}

public enum TaskStatus
{
    InProgress,
    Completed
}

// Alerts
[System.Serializable]
public class Alerts
{
    public List<AlertObj> AllAlerts = new List<AlertObj>();
}

[System.Serializable]
public class AlertObj
{
    public int id_in_danger;
    public string vital;
    public float vital_val;
}

// Breadcrumbs
public enum BreadCrumbType
{
    backtracking,
    navigation
}

[System.Serializable]
public class AllBreadCrumbs
{
    public List<Breadcrumb> AllCrumbs = new List<Breadcrumb>();
}

[System.Serializable]
public class Breadcrumb
{
    public Location location;
    public BreadCrumbType type;
}

// Location
[System.Serializable]
public class Location
{
    public double latitude;
    public double longitude;
    public int id;
}

// Data of other Fellow Astronauts
[System.Serializable]
public class FellowAstronauts
{
    public List<FellowAstronaut> AllFellowAstronauts = new List<FellowAstronaut>();
}

[System.Serializable]
public class FellowAstronaut
{
    public int AstronautID;
    public Location location;
    public string color;
    public Vitals vitals;
    public bool navigating;
    public AllBreadCrumbs bread_crumbs;
}