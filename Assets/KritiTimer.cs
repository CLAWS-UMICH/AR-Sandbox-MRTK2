using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KritiTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private IEnumerator updateTimeCoroutine;
    private int seconds = 0;
    private int minutes = 0;
    private int hours = 0;
    [SerializeField] private TextMeshPro clock;
    void Start()
    {
        clock = gameObject.GetComponentInChildren<TextMeshPro>();
        updateTimeCoroutine = updateTime();
        StartCoroutine(updateTimeCoroutine);
    }
    private string Zeroes(int time){        
        if (time < 10)
        {
            return "0" + time.ToString();
        }
        else
            return time.ToString();
    }

    private IEnumerator updateTime(){
        while (true){
            yield return new WaitForSeconds(1);
            if(seconds==59){
                seconds = -1;
                minutes++;
            }
            seconds++;
            if(minutes==59){
                minutes = 0;
                hours++;
            }
            clock.text = Zeroes(hours) + ":" + Zeroes(minutes) + ":" + Zeroes(seconds);
            // updateCorrectSection(ref timeInSeconds, ref timeInMinutes);
            // updateCorrectSection(ref timeInMinutes, ref timeInHours);
            // gameObject.GetComponentInChildren<BohnettUI>().SetTime(timeInSeconds, timeInMinutes, timeInHours);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
