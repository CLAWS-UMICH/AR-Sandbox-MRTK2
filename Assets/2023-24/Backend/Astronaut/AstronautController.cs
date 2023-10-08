using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Message otherMessage = (Message)obj;
        return id == otherMessage.id &&
               sent_to == otherMessage.sent_to &&
               message == otherMessage.message &&
               from == otherMessage.from;
    }
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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Geosample otherGeo = (Geosample)obj;
        return id == otherGeo.id &&
               spec_data.Equals(otherGeo.spec_data) &&
               time == otherGeo.time &&
               location.Equals(otherGeo.location) &&
               author == otherGeo.author;
    }
}

[System.Serializable]
public class SpecData
{
    public int rock_example_data;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        SpecData otherSpecData = (SpecData)obj;
        return rock_example_data == otherSpecData.rock_example_data;
    }
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
    public int type; // 0 = regular, 1 = danger, 2 = geo
    public int author;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Waypoint otherWay = (Waypoint)obj;
        return id == otherWay.id &&
               location.Equals(otherWay.location) &&
               type == otherWay.type &&
               author == otherWay.author;
    }
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
    public int id;
    public int status; // 0 = InProgress, 1 = Completed
    public string title;
    public string description;
    public int shared_with;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        TaskObj otherTask = (TaskObj)obj;
        return id == otherTask.id &&
               title == otherTask.title &&
               description == otherTask.description &&
               status == otherTask.status &&
               shared_with == otherTask.shared_with;
    }
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
    public int id;
    public int id_in_danger;
    public string vital;
    public float vital_val;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        AlertObj otherAlert = (AlertObj)obj;
        return id == otherAlert.id &&
               id_in_danger == otherAlert.id_in_danger &&
               vital == otherAlert.vital &&
               vital_val == otherAlert.vital_val;
    }
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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        AllBreadCrumbs otherCrumbs = (AllBreadCrumbs)obj;

        // Compare lists using the SequenceEqual method from System.Linq
        return AllCrumbs.SequenceEqual(otherCrumbs.AllCrumbs);
    }
}

[System.Serializable]
public class Breadcrumb
{
    public int id;
    public Location location;
    public BreadCrumbType type;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Breadcrumb otherBread = (Breadcrumb)obj;
        return id == otherBread.id &&
               location.Equals(otherBread.location) &&
               type == otherBread.type;
    }
}

// Location
[System.Serializable]
public class Location
{
    public double latitude;
    public double longitude;
    public int id;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Location otherLoc = (Location)obj;
        return id == otherLoc.id &&
               latitude == otherLoc.latitude &&
               longitude == otherLoc.longitude;
    }
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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        FellowAstronaut otherA = (FellowAstronaut)obj;
        return AstronautID == otherA.AstronautID &&
               location.Equals(otherA.location) &&
               color == otherA.color &&
               vitals.Equals(otherA.vitals) &&
               navigating == otherA.navigating &&
               bread_crumbs.Equals(otherA.bread_crumbs);
    }
}