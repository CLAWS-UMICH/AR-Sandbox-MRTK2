using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoniaTimer : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;
    private float totalSeconds = 0;
    private bool timerRunning = false;

    private void Update()
    {
        if (timerRunning)
        {
            totalSeconds += Time.deltaTime;
            timerText.text = FormatTime(totalSeconds);
        }
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void ResetTimer()
    {
        totalSeconds = 0;
        timerText.text = FormatTime(totalSeconds);
        timerRunning = false;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    private string FormatTime(float totalSeconds)
    {
        int hours = (int) totalSeconds / 3600;
        int minutes = (int) totalSeconds % 3600 / 60;
        int seconds = (int) totalSeconds % 60;

        return hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
