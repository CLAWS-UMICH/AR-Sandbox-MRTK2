/*
 Name: Wenjia
 Desc: following C# scripting tutorial
 */

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class TimerScriptWenjia : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject screen;
    public TextMeshPro timer;
    public GameObject start_button;
    public GameObject pause_button;
    public GameObject stop_button;

    static int hour = 0;
    static int minute = 0;
    static int second = 0;
    static int frame = 0;
    static Boolean pause = true;

    public void Start()
    {
        screen = GameObject.Find("screen");
        timer = screen.transform.Find("Text").gameObject.GetComponent<TextMeshPro>();
        start_button = GameObject.Find("start");
        pause_button = GameObject.Find("pause");
        stop_button = GameObject.Find("stop");
        updateTime();
    }

    public void Update()
    {
        if (!pause)
        {
            updateTime();
            frame++;
            if(frame%3600 == 0)
            {
                second++;
                frame = 0;
                if(second%59 == 0)
                {
                    minute++;
                    second = 0;
                    if(minute %59 == 0)
                    {
                        hour++;
                        minute = 0;
                    }
                }
            }
        }
    }
    // Update is called once per frame
  

    public void updateTime()
    {
        String currentTime = "";
        if(hour < 10)
        {
            currentTime += "0" + hour;
        } else
        {
            currentTime += hour;
        }
        currentTime += ":";
        if (minute < 10)
        {
            currentTime += "0" + minute;
        } else
        {
            currentTime += minute;
        }
        currentTime += ":";
        if(second < 10)
        {
            currentTime += "0" + second;
        } else
        {
            currentTime += second;

        }
        timer.text = currentTime;
    }

    public void StartTime()
    {
        // start timer
        ResetTime();
        pause = false;
        updateTime();
    }

    public void Pause()
    {
        // pause timer
        pause = true;
        updateTime();

    }

    public void ResetTime()
    {
        // reset timer
        pause = true;
        hour = 0;
        minute = 0;
        second = 0;
        updateTime();

    }
}
