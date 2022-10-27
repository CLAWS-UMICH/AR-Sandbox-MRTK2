using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelinaCount : MonoBehaviour
{
    int currentTime = 0f;
    int minuteNum = 0;
    int hrNum = 0;
    int StartTime = 0f;

    [SerializedField] TextMeshPro hour;
    [SerializedField] TextMeshPro minute;
    [SerializedField] TextMeshPro second;

    void Start()
    {
        currentTime = StartTime;
    }

    
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        second.text = currentTime.ToString();
        minute.text = minuteNum.ToString();
        hour.text = hrNum.ToString();

        if (currentTime == 60) {
            currentTime = 0;
            minuteNum += 1;
        }

        if (minuteNum == 60) {
            minuteNum = 0;
            hrNum += 1;
        }
    }
}
