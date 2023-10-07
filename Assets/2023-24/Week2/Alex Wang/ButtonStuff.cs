using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ButtonStuff : MonoBehaviour
{
    GameObject screen;
    TextMeshPro textMeshPro;
    private float elapsedTime;
    private bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        textMeshPro = screen.transform.Find("Title").gameObject.GetComponent<TextMeshPro>();
        UpdateTimerText();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateTimerText()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        textMeshPro.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
    }

    public void StartClock()
    {
        isRunning = true;
        StartCoroutine(Clock());
     
    }

    public void Reset()
    {
        elapsedTime = 0f;
        
        UpdateTimerText();
        isRunning = false;
        StopCoroutine(Clock());
    }

    public void Pause()
    {
        isRunning = false;
        StopCoroutine(Clock());
    }

    IEnumerator Clock()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(1);
            elapsedTime++;
            UpdateTimerText();
        }      
    }
}
