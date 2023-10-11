using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // needed for text

public class BrianClockHandler : MonoBehaviour
{
    GameObject screen1;
    GameObject screen2;
    TextMeshPro textObject;
    bool timerOn = false;
    int elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        screen1 = GameObject.Find("Screen"); // Look for the parent object called Screen
        screen2 = screen1.transform.Find("Screen1").gameObject; // Get child parent object called Screen1
        textObject = screen2.transform.Find("Title").gameObject.GetComponent<TextMeshPro>(); // Find the child of Screen1 called Title
        textObject.text = "00:00:00"; // Set the text component
    }

    public void StartClock()
    {
        timerOn = true;
        StartCoroutine(_Clock());
    }
    public void StopClock()
    {
        timerOn = false;
        StopCoroutine(_Clock());
    }
    public void ResetClock()
    {
        timerOn = false;
        StopCoroutine(_Clock());
        elapsedTime = 0;
        textObject.text = "00:00:00";
    }
    IEnumerator _Clock()
    {
        while (timerOn) // Runs while the timer is on
        {
            textObject.text = Format(elapsedTime); // Sets the correct text
            elapsedTime++;
            yield return new WaitForSeconds(1); // Waits 1 second
        }
    }
    string Format(int elapsedTimeInSeconds)
    {
        int hours = elapsedTimeInSeconds / 3600;
        int minutes = (elapsedTimeInSeconds % 3600) / 60;
        int seconds = elapsedTimeInSeconds % 60;
        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
}
