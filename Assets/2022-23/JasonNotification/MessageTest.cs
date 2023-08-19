using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageTest : MonoBehaviour
{
    public GameObject notif;
    public NotifType type;
    private NotifContent contentScript;

    public enum NotifType
    {
        Message,
        Warning,
        Error
    }

    // Start is called before the first frame update
    public void CreateNotif()
    {
        Instantiate(notif);
        string title;
        string subtitle;
        contentScript = notif.GetComponent<NotifContent>();
        switch(type)
        {
            case NotifType.Message:
                title = "From Bob:";
                subtitle = "potato";
                break;
            case NotifType.Warning:
                title = "Low Potato Warning!";
                subtitle = "Estimated time: 30 seconds";
                break;
            case NotifType.Error:
                title = "Error";
                subtitle = "The potato is broke";
                break;
            default:
                title = "wtf";
                subtitle = "happened";
                break;
        }
        contentScript.editNotif(title, subtitle);
    }
}
