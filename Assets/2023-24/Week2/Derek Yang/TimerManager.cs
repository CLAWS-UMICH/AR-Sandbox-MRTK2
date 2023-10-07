using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro timer;
    [SerializeField] private float time = 0f;
    [SerializeField] private bool isTimerRunning;

    public void StartTimer()
    {
        isTimerRunning = true;
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        while (isTimerRunning)
        {
            yield return new WaitForSeconds(1);

            time++;
            float hours = Mathf.FloorToInt(time / 60 / 60);
            float minutes = Mathf.FloorToInt(time / 60 % 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timer.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        }
    }

    IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(1);
        time = 0f;
        timer.text = "00:00:00";
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        StopCoroutine(TimerCoroutine());
    }

    public void ResetTimer()
    {
        isTimerRunning = false;
        StopCoroutine(TimerCoroutine());
        StartCoroutine(ResetCoroutine());
    }
}
