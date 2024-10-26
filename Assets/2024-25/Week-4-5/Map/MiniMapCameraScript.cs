using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    private Transform playerpos;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.find("PlayerMapIcon");
        if (player != null) playerpos=player.transform;
        else Debug.LogError("Player GameObject not found.");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        float playerX = playerpos.position.x; 
        transform.position = new Vector3(playerX, transform.position.y, transform.position.z);
    }
}
