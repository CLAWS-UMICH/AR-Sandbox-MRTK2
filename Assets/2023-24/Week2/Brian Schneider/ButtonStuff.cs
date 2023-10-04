using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStuff : MonoBehaviour
{
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Cube");
    }

    public void PressButton()
    {
        obj.SetActive(!obj.activeSelf);
        Debug.Log("Object clicked");
    }
}
