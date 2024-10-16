using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartButton : MonoBehaviour
{   
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject resetButton;
    public TextMeshProUGUI timerText;
    public GameObject canvas;
    float elapsedTime = 0f;
    bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {   
        
        startButton = GameObject.Find("StartButton");
        stopButton = GameObject.Find("StopButton");
        resetButton = GameObject.Find("ResetButton");

        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        timerText.text = "00:00:00";
    }

    void Awake()
    {
        startButton = GameObject.Find("StartButton");
        stopButton = GameObject.Find("StopButton");
        resetButton = GameObject.Find("ResetButton");
    }
    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimer(elapsedTime);
        }
    }

    void UpdateTimer(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600); 
        int minutes = Mathf.FloorToInt((time % 3600) / 60); 
        int seconds = Mathf.FloorToInt(time % 60); 

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void StartB()
    {
        isRunning = true;
        Debug.Log("test");
    }

    public void StopB()
    {
        isRunning = false;
        Debug.Log("test1");
    }

    public void ResetB()
    {
        isRunning = false;
        elapsedTime = 0f;
        timerText.text = "00:00:00";
    }
}
