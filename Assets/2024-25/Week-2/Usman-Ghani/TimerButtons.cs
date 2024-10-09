using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerButtons : MonoBehaviour
{
    GameObject screen;
    TextMeshPro textMeshPro;
    private float currentTime = 0f;
    private Coroutine timerCoroutine;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("UI Backplate(Clone)");
        textMeshPro = screen.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshPro>();
    }

    public void StartClock() {
        if (timerCoroutine == null){
            started = true;
            timerCoroutine = StartCoroutine(Clock());
        }
    }

    public void StopClock() {
        if (timerCoroutine != null) {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        started = false;
    }

    public void ResetClock() {
        StopClock();
        currentTime = 0f;
        textMeshPro.text = "00:00:00";
    }

    void UpdateText() {
        int hours = Mathf.FloorToInt(currentTime / 3600);
        int minutes = Mathf.FloorToInt((currentTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        //textMeshPro.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        textMeshPro.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    private IEnumerator Clock() {
        while (started) {
            yield return new WaitForSeconds(0.1f);
            currentTime += 0.1f;
            UpdateText();
        }
    }
}