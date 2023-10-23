using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Derek Yang
public class Minimap : MonoBehaviour
{
    public Transform player;

    // Updates camera to match player movements (but not rotation)
    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
