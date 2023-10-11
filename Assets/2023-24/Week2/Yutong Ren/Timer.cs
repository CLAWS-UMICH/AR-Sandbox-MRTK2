using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime;
    private bool isRunning;

    void Start()
    {
        // Initialize the timer
        ResetTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            // Update the timer text
            elapsedTime += Time.deltaTime;
            DisplayTime(elapsedTime);
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = false;
        DisplayTime(elapsedTime);
    }

    private void DisplayTime(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
