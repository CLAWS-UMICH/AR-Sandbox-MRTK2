/*
Name: Derek Yang
Desc: Get reference to ScrollHandler script attached to ScrollObjects GameObject
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScrollObjects : MonoBehaviour
{

    [SerializeField] private ScrollHandler scrollHandler;

    // Start is called before the first frame update
    void Start()
    {
        scrollHandler = GameObject.Find("ScrollObjects").GetComponent<ScrollHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
