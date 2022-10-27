using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumbMain : MonoBehaviour
{
    [SerializeField] private bool buttonStatus;
    [SerializeField] private int pressedNumber;

    private float elapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        buttonStatus = false;
        pressedNumber = 0;
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            if (buttonStatus)
            {
                Debug.Log("but");
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void pressed()
    {
        pressedNumber++;
        if (pressedNumber == 1)
        {
            buttonStatus = true;
        }
        else if (pressedNumber == 2)
        {
            pressedNumber = 0;
            buttonStatus = false;
        }
    }
}
