/*
 * Name: Jefford Shau
 * Desc: Timer Unity
 */

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // initialize hours, minutes, seconds
    // initialize pause status for start, stop
    public static int hour = 0;
    public static int minute = 0;
    public static int second = 0;
    public static Boolean pause = true;

    GameObject screen;
    TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        text = screen.transform.Find("Title").gameObject.GetComponent<TextMeshPro>();
        text.text = FormatTime(hour, minute, second);
        StartCoroutine(TimerLoop());
    }

    // Update is called once per frame
    IEnumerator TimerLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!pause)
            {
                second++;
                if (second % 60 == 0)
                {
                    minute++;
                    second = 0;
                }
                else if (minute % 60 == 0 && minute != 0)
                {
                    hour++;
                    minute = 0;
                }
            }
            text.text = FormatTime(hour, minute, second);
            Debug.Log(text.text);
        }
    }

    public void StartTime()
    {
        pause = false;
    }

    public void PauseTime()
    {
        pause = true;
    }

    public void ResetTime()
    {
        pause = true;
        hour = 0;
        minute = 0;
        second = 0;
        text.text = FormatTime(hour, minute, second);
    }

    public string FormatTime(int hour, int min, int sec)
    {
        return hour.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
    }
}

