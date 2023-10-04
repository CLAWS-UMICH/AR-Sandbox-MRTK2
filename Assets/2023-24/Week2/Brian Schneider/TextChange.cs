using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextChange : MonoBehaviour
{
    GameObject screen;
    TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        textMeshPro = screen.transform.Find("Text").gameObject.GetComponent<TextMeshPro>();
    }

    public void ChangeText()
    {
        textMeshPro.text = "CLAWS IS COOL!"; 
    }
}
