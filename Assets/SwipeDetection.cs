using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    // public Player player1;
    // public Sprite Selina;
    public int pixelDectDis = 40;
    private bool fingerDown;
    void update() {
        Touch touch = Input.GetTouch(0);
        Vector3 startPos = Camera.main.ScreenToWorldPoint(touch.position);
        startPos.z = 0f;
        Vector3 currentPos = startPos;
        

        Debug.Log("fingerDown");

        // if (fingerDown == false && Input.touchCount > 0 && touch.phase == TouchPhase.Began) {
        //     fingerDown = true;
        // }

        // if (fingerDown) {
        //     Debug.Log("fingerDown");
            
        // }

        if (touch.position.y >= startPos.y + pixelDectDis) {
            fingerDown = false;
            currentPos.y = startPos.y + pixelDectDis;
            currentPos.x = startPos.x;
            transform.position = currentPos;
            Debug.Log("Swiped up");
        }
        else if (touch.position.x <= startPos.x - pixelDectDis) {
            fingerDown = false;
            currentPos.y = startPos.y;
            currentPos.x = startPos.x - pixelDectDis;
            transform.position = currentPos;
            Debug.Log("Swiped left");
        }
        else if (touch.position.x >= startPos.x + pixelDectDis) {
            fingerDown = false;
            currentPos.y = startPos.y;
            currentPos.x = startPos.x + pixelDectDis;
            transform.position = currentPos;
            Debug.Log("Swiped right");
        }
        else if (touch.position.y <= startPos.y - pixelDectDis) {
            fingerDown = false;
            currentPos.y = startPos.y - pixelDectDis;
            currentPos.x = startPos.x;
            transform.position = currentPos;
            Debug.Log("Swiped down");
        }

        // if (fingerDown && Input.touchCount > 0 && touch.phase == TouchPhase.Ended) {
        //     fingerDown = false;
        // }

        //testing for PC

        if (fingerDown == false && Input.GetMouseButtonDown(0)) {
            startPos = Input.mousePosition;
            fingerDown = true;
        }

        if (fingerDown) {
            Debug.Log("fingerDown");
            if (Input.mousePosition.y >= startPos.y + pixelDectDis) {
                fingerDown = false;
                Debug.Log("Swipe up");
            }
            else if (Input.mousePosition.x <= startPos.x - pixelDectDis) {
                fingerDown = false;
                Debug.Log("Swiped left");
            }
            else if (Input.mousePosition.x >= startPos.x + pixelDectDis) {
                fingerDown = false;
                Debug.Log("Swiped right");
            }
        }
    }
}
