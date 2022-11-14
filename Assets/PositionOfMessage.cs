using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class PositionOfMessage
{

    // if window is at (0,0,0)
    [SerializeField] static float x = 0.31F;
    [SerializeField] static float y = 0.22F;
    [SerializeField] static float z = 0.00F;
    [SerializeField] static float heightOfBox = 0.12F;

    
    public static Vector3 getPosition() {
        y -= heightOfBox;
        return new Vector3(x, y, z);
    }

}
