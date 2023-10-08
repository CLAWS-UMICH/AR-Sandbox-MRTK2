using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoStuff : MonoBehaviour
{
    TextMeshPro text;
    GameObject screen;
    GameObject button1;
    GameObject button2;
    private bool isRunning;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        text = screen.transform.Find("Text").gameObject.GetComponent<TextMeshPro>();
        isRunning = false;
    }

    public void StartTimer()
    {
        text.text = "hi";
        Debug.Log("start clicked");
    }

    public void StopTimer()
    {
        text.text = "bye";
        Debug.Log("Stop clicked");
    }

    public void ResetTimer()
    {
        text.text = "a;wethawet";
        Debug.Log("Reset clicked");
    }

    private void Update()
    {
        text.text = "aweutha";
    }
}
