using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumbMain : MonoBehaviour
{
    [SerializeField] private GameObject crumb;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject camera;

    private bool _buttonStatus;
    private bool _collided;
    private int pressedNumber;
    private GameObject crumbObject;

    private Vector3 prevPosition;
    private Vector3 currentPosition;
    private GameObject _collisionCrumbObject;

    private float distance;

    // Get Function to see if button is on or off
    public bool ButtonStatus
    {
        get
        {
            return _buttonStatus;
        }
    }

    // If i want to use another script to destroy the crumb on collision
    /*
    public GameObject CollisionTrue
    {
        set
        {
            _collided = true;
            _collisionCrumbObject = value;
        }
    */


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
            // While the button is pressed this runs
            if (_buttonStatus)
            {
                // Gets current position of camera (player)
                currentPosition = camera.transform.position;

                // Calculates the distance of current position with previous position
                distance = Vector3.Distance(currentPosition, prevPosition);

                // If distance is greater than 1, creates a crumb object at the previous position
                // Then resets the previous position to current position
                if (distance > 1)
                {
                    crumbObject = (GameObject)Instantiate(crumb, prevPosition, Quaternion.identity, transform);
                    crumbObject.name = "crumb";
                    prevPosition = currentPosition;
                }

                // If collided, crumb is broken (only used if we want to use another script)
                /*
                if (_collided) 
                {
                    Destroy(_collisionCrumbObject);
                    _collided = false;
                }
                */
            }
            yield return new WaitForSeconds(1);
        }
    }

    // Function to set variable if the button is pressed or not
    public void pressed()
    {
        pressedNumber++;
        if (pressedNumber == 1)
        {
            _buttonStatus = true;
            prevPosition = currentPosition = camera.transform.position;
        }
        else if (pressedNumber == 2)
        {
            pressedNumber = 0;
            _buttonStatus = false;
        }
    }
}
