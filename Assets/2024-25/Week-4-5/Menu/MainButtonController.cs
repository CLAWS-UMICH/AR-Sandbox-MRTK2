using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainButtonController : MonoBehaviour
{

    GameObject MainScreen;
    GameObject TimerScreen;
    GameObject ClockScreen;
    Boolean isTimerOpen = false;
    Boolean isClockOpen = false;
    int mainScreenCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        MainScreen = GameObject.Find("MainScreen");
        TimerScreen = GameObject.Find("TimerScreen");
        ClockScreen = GameObject.Find("ClockScreen");
        TimerScreen.SetActive(false);
        ClockScreen.SetActive(false);
    }

    public void OpenTimer() {
        
        if (isTimerOpen) {
            isTimerOpen = false;
            TimerScreen.SetActive(false);
        } else {
            isTimerOpen = true;
            TimerScreen.SetActive(true);
        }

    }

    public void Duplicate() {
        Vector3 offset = new Vector3(0, 0.05f * mainScreenCount, -mainScreenCount/10.0f);
        GameObject duplicate = Instantiate(MainScreen, MainScreen.transform.position + offset, MainScreen.transform.rotation);

        TextMeshPro duplicateText = duplicate.transform.Find("Text").GetComponent<TextMeshPro>();
        duplicateText.text = "Menu " + mainScreenCount;

        duplicate.name = "MainScreen" + mainScreenCount;
        mainScreenCount++;
    }

    public void OpenClock() {
        if (isClockOpen) {
            isClockOpen = false;
            ClockScreen.SetActive(false);
        } else {
            isClockOpen = true;
            ClockScreen.SetActive(true);
        }
    }
}
