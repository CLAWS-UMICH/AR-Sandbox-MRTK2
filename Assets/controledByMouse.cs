using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controledByMouse : MonoBehaviour
{

    // GameObject g;

    public void moveObjectByMouse () {
        float moveSpeed = 10;
        //Define the speed at which the object moves.

        Vector3 mousePos = Input.mousePosition;
        Debug.Log("Click");
//  * moveSpeed * Time.deltaTime
        // button values are 0 for left button, 1 for right button, 2 for the middle button
        if (Input.GetMouseButton(0)) {
            Debug.Log("hold");
            Debug.Log(mousePos);
            // need to turn the mousePos to the pos in game
            transform.position = new Vector3(mousePos[0] / 572f, mousePos[1] / 355f, 0);
        }
        
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
