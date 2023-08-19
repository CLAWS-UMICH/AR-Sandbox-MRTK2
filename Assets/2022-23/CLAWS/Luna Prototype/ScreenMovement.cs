using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMovement : MonoBehaviour
{
    [SerializeField] float xOffset = 0.0f;
    [SerializeField] float yOffset = 0.0f;
    [SerializeField] float zOffset = 0.0f;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = cam.transform.transform.position;
        transform.position = new Vector3(camPos.x - xOffset, camPos.y - yOffset, camPos.z - zOffset);
    }
}
