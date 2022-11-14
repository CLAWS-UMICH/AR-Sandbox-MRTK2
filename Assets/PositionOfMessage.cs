using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PositionOfMessage : MonoBehaviour
{

    private static float x;
    private static float y;
    private static float z;
    private static float heightOfBox = 0.12F;

    [SerializeField] GameObject window;
    
    // the script is not enabled (used in onclick()), 
    // so we should use awake instead of start?
    void Awake() {
        // Set up the first position of the message box basing on the position of the window
        Transform t  = transform;
        Vector3 pos = t.position;
        x = pos[0] + 0.2F;
        y = pos[1] + 0.1F;
        z = pos[2];
    }

    public Vector3 getPosition() {
        y -= heightOfBox;
        return new Vector3(x, y, z);
    }

}
