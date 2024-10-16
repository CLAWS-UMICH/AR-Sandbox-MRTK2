using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Ensure this namespace is added

public class TimerStart : MonoBehaviour
{
    bool TimerGoing = false;

    int Hour = 0;
    int Minute = 0;
    int Second = 0;

    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        if (textMeshPro == null || startButton == null || stopButton == null || resetButton == null)
        {
            Debug.LogError("One or more UI components are not assigned in the Inspector.");
            return;
        }

        startButton.onClick.AddListener(StartClick);
        stopButton.onClick.AddListener(StopClick);
        resetButton.onClick.AddListener(ResetClick);

        Debug.Log("Start method executed. UI Components are set.");
    }

    IEnumerator _SecondWaiter()
    {
        yield return new WaitForSeconds(1);
    }

    public void StartClick()
    {
        if (!TimerGoing)
        {
            TimerGoing = true;
            Debug.Log("Timer Started");
            StartCoroutine(RunTimer());
        }
    }

    IEnumerator RunTimer()
    {
        while (TimerGoing)
        {
            yield return new WaitForSeconds(1);
            Second++;
            if (Second == 60)
            {
                Minute++;
                Second = 0;
            }
            if (Minute == 60)
            {
                Hour++;
                Minute = 0;
            }
            textMeshPro.text = $"{Hour:D2}:{Minute:D2}:{Second:D2}";
            Debug.Log($"Timer Updated: {Hour:D2}:{Minute:D2}:{Second:D2}");
        }
    }

    public void StopClick()
    {
        TimerGoing = false;
        Debug.Log("Timer Stopped");
    }

    public void ResetClick()
    {
        TimerGoing = false;
        Minute = 0;
        Second = 0;
        Hour = 0;
        textMeshPro.text = $"{Hour:D2}:{Minute:D2}:{Second:D2}";
        Debug.Log("Timer Reset");
    }
}