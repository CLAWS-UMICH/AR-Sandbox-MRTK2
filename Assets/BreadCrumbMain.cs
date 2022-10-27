using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumbMain : MonoBehaviour
{
    [SerializeField] private bool _buttonStatus;
    [SerializeField] private GameObject crumb;
    [SerializeField] private GameObject parent;

    private int pressedNumber;
    private GameObject crumbObject;
    private int crumCount = 0;

    public bool ButtonStatus
    {
        get
        {
            return _buttonStatus;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _buttonStatus = false;
        pressedNumber = 0;
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            if (_buttonStatus)
            {
                crumCount++;
                crumbObject = (GameObject) Instantiate(crumb, transform);
                crumbObject.name = "c" + crumCount;
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void pressed()
    {
        pressedNumber++;
        if (pressedNumber == 1)
        {
            _buttonStatus = true;
        }
        else if (pressedNumber == 2)
        {
            pressedNumber = 0;
            _buttonStatus = false;
        }
    }
}
