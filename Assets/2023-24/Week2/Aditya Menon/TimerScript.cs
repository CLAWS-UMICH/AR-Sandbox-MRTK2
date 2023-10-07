using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    GameObject screen;
    TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        textMeshPro = screen.transform.Find("Text").gameObject.GetComponent<TextMeshPro>();
        textMeshPro.text = "HH:MM:SS";
    }
    public void StartTimer()
    {
        textMeshPro.text = "00:00:01";
    }
    public void StopTimer()
    {
        textMeshPro.text = "00:00:02";
    }
    public void ResetTimer()
    {
        textMeshPro.text = "00:00:00";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
