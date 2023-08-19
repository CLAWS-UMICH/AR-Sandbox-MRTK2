using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseScreen : MonoBehaviour
{
    private bool screenOn;
    [SerializeField] GameObject screenBody;
    // Start is called before the first frame update
    void Start()
    {
        screenOn = true;
    }

    public void changeScreen()
    {
        if (screenOn)
        {
            Debug.Log("Test1");
            screenOn = false;
            screenBody.SetActive(false);
        } else
        {
            screenOn = true;
            screenBody.SetActive(true);
            Debug.Log("Test2");
        }
    }
}
