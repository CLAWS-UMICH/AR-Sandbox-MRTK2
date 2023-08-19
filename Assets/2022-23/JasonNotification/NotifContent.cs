using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotifContent : MonoBehaviour
{
    public TextMeshPro titleText;
    public TextMeshPro subtitleText;

    public void editNotif(string title, string subtitle)
    {
        titleText.text = title;
        subtitleText.text = subtitle;
    }
}
