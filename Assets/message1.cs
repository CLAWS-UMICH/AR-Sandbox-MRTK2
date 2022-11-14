using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class message1 : MonoBehaviour
{

    [SerializeField] TextMeshPro windowsTmp;
    [SerializeField] string buttonTmp;
    [SerializeField] GameObject message; // from prefab


    public void click() {
        // windowsTmp.text = buttonTmp; 
        // Instantiate at position (0, 0, 0) and zero rotation.
        // Instantiate(messageBox, new Vector3((float)-0.113, (float)-0.209, (float)0.06), Quaternion.identity);
        // Instantiate(message, new Vector3(x, y, z), Quaternion.identity);

        Instantiate(message, PositionOfMessage.getPosition(), Quaternion.identity);
        Debug.Log(buttonTmp);
        // create distance for the next box
        GameObject messageBox = message.transform.GetChild(0).gameObject;; // from prefab
        // To find `child1` which is the first index(0)
        // Get the GameObject Text(TMP)
        GameObject messageContent = messageBox.transform.GetChild(0).gameObject;
        // Get the Text(TMP)'s component
        TextMeshPro tmp = messageContent.GetComponent<TextMeshPro>();
        Debug.Log(tmp.text);
        tmp.text = buttonTmp; 
        Debug.Log(tmp.text);
    }

}
