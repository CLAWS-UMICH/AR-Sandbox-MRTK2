using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Astronaut
{
    public int AstronautId;

    public Messaging MessagingData;
    public Vitals VitalsData;
    public Geosample GeosampleData;
    public Waypoint WaypointData;
    public Tasklist TasklistData;
    public Alert AlertData;
    public List<Breadcrumb> BreadCrumbs = new List<Breadcrumb>();
    public Location location;
    public bool currently_navigating;
    public bool inDanger;
    public string color;
}
