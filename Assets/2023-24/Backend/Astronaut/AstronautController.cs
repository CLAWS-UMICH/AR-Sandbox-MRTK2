using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Messaging
{
    public int id;
    public string sent_to;
    public string message;
    public int received_from;
}

[System.Serializable]
public class Vitals
{
    public int heart_rate;
    public float oxygen;
    public float suit_temp;
}

[System.Serializable]
public class Geosample
{
    public int id;
    public SpecData spec_data;
    public string time;
    public Location location;
}

[System.Serializable]
public class SpecData
{
    public int roack_example_data;
}

[System.Serializable]
public class Waypoint
{
    public int id;
    public Location location;
    public WaypointType type;
}

public enum WaypointType
{
    regular,
    danger,
    geo
}

[System.Serializable]
public class Tasklist
{
    public List<TaskObj> TaskList = new List<TaskObj>();
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

[System.Serializable]
public class Alert
{
    public int id_in_danger;
    public string vital;
    public float vitalVal;
}

public enum BreadCrumbType
{
    backtracking,
    navigation
}

[System.Serializable]
public class Breadcrumb
{
    public Location location;
    public BreadCrumbType type;
}

[System.Serializable]
public class Location
{
    public double latitude;
    public double longitude;
}
