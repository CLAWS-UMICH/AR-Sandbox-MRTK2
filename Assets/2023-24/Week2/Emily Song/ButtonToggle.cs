using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonToggle : MonoBehaviour
{
    GameObject screen;
    TextMeshPro timer;
    float elapsedTime;
    bool on = false;

    // Start is called before the first frame update
    public void Start()
    {
        screen = GameObject.Find("Screen");
        timer = screen.transform.Find("Timer").gameObject.GetComponent<TextMeshPro>();
        timer.text = "00:00:00";
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    public void StartClock()
    {
        if(on == false)
        {
            on = true;
            StartCoroutine(_Clock());
        }

        
    }
    public void ResetClock()
    {
        on = false;
        StopCoroutine(_Clock());
        timer.text = "00:00:00";
        elapsedTime = 0;
        
    }

    public void StopClock()
    {
        on = false;
        StopCoroutine(_Clock());
    }


    public void UpdateTimer(string timerString)
    {
        timer.text = timerString;
    }

    IEnumerator _Clock()
    {
        //yield return new WaitForSeconds(1);
        //seconds++;
        while (on)
        {
            elapsedTime ++;

            int hours = Mathf.FloorToInt(elapsedTime / 3600);
            int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            string timerString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

            //timer.text = timerString;
            UpdateTimer(timerString);

            yield return new WaitForSeconds(1); // Wait for 1 second
        }
    }



}
