using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // needed for text

public class TimerExampleScript : MonoBehaviour
{
    GameObject screen;
    TextMeshPro text;
    private float elapsedTime = 0f;
    private Coroutine timerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        text = screen.transform.Find("Text").gameObject.GetComponent<TextMeshPro>();
        text.text = "00:00:00";
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
        elapsedTime = 0f;
        text.text = "00:00:00";
    }
    private IEnumerator Clock()
    {
        while (true)
        {
            elapsedTime += Time.deltaTime; // Increment the time
            Format(elapsedTime); // Update the text
            yield return null; // Wait for the next frame
        }
    }
    void Format(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        text.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
}
