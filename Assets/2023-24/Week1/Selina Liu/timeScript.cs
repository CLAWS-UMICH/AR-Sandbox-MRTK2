using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class timeScript : MonoBehaviour
{
    //private GameObject timeTextObject;
    public TextMeshPro timerTextTM;
    public Button startButton;
    public Button pauseButton;
    public Button resetButton;

    private float currentTime = 0f;
    private bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        timerTextTM.text = "00:00:00";
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
        }
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int hours = Mathf.FloorToInt(currentTime / 3600);
        int minutes = Mathf.FloorToInt((currentTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerTextTM.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
    }

    public void StartTimer()
    {
        isRunning = true;
        Debug.Log(currentTime);
    }

    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        UpdateTimerText();
        isRunning = false;
    }
}
