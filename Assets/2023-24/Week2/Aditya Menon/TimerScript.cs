using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public GameObject screen;
    TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        textMeshPro = screen.transform.Find("Text").gameObject.GetComponent<TextMeshPro>();
        textMeshPro.text = "CLAWS IS COOL!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
