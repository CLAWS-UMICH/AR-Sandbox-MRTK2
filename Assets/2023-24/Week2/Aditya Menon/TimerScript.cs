using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    int secondsCount = 0;
    int minutesCount = 0;
    int hoursCount = 0;
    GameObject screen;
    TextMeshPro textMeshPro;
    bool isTimerRunning = false;
    private IEnumerator timerCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        textMeshPro = screen.transform.Find("Text").gameObject.GetComponent<TextMeshPro>();
        textMeshPro.text = "HH:MM:SS";
        timerCoroutine = _UpdateTimer();
    }
    public void StartTimer()
    {
        if(isTimerRunning==false)
        {
            StartCoroutine(timerCoroutine);
            isTimerRunning = true;
        }
    }
    public void StopTimer()
    {
        StopCoroutine(timerCoroutine);
        isTimerRunning = false;
    }
    public void ResetTimer()
    {
        StopTimer();
        secondsCount = 0;
        minutesCount = 0;
        hoursCount = 0;
        textMeshPro.text = "00:00:00";
    }
    IEnumerator _UpdateTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            textMeshPro.text = UpdateCount();
        }
    }
    string UpdateCount()
    {
        if(minutesCount==59 && secondsCount==59)
        {
            hoursCount++;
            minutesCount = 0;
            secondsCount = 0;
        }
        else if (secondsCount == 59)
        {
            minutesCount++;
            secondsCount = 0;
        }
        else
        {
            secondsCount++;
        }
        string counter = "";
        string hoursString = "";
        string minutesString = "";
        string secondsString = "";
        if(hoursCount < 10)
        {
            hoursString = "0" + hoursCount.ToString();
        }
        else
        {
            hoursString = hoursCount.ToString();
        }

        if(minutesCount < 10)
        {
            minutesString = "0" + minutesCount.ToString();
        }
        else
        {
            minutesString = minutesCount.ToString();
        }

        if (secondsCount < 10)
        {
            secondsString = "0" + secondsCount.ToString();
        }
        else
        {
            secondsString = secondsCount.ToString();
        }
        counter = hoursString + ":" + minutesString + ":" + secondsString;
        return counter;
    }
  

}
