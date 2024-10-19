using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{

    TextMeshPro text;
    private float timeElapsed = 0f;
    private Coroutine timerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Text").GetComponent<TextMeshPro>();
        text.text = "00:00:00";
    }

    void OnDisable()
    {
        StopClock();
    }


    private IEnumerator Clock()
    {
        while (true)
        {
            timeElapsed += Time.deltaTime;

            int h = Mathf.FloorToInt(timeElapsed / 3600);
            int m = Mathf.FloorToInt((timeElapsed % 3600) / 60);
            int s = Mathf.FloorToInt(timeElapsed % 60);

            text.text = $"{h:D2}:{m:D2}:{s:D2}"; 

            yield return null; 
        }
    }

    public void StartClock()
    {
        if (timerCoroutine == null)
            timerCoroutine = StartCoroutine(Clock());
    }

    public void StopClock()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    public void ResetClock()
    {
        StopClock();
        timeElapsed = 0f;
        text.text = "00:00:00";
    }
    
}
