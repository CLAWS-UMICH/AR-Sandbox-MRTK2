using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartTimer : MonoBehaviour
{
    GameObject canvas;
    TextMeshProUGUI textMeshPro;
    private Coroutine timerCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        textMeshPro = canvas.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(textMeshPro);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressStartButton()
    {
        if(timerCoroutine == null){
            timerCoroutine = StartCoroutine(_StartTimerCoroutine());
        }
    }

    public void PressStopButton()
    {
        if(timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    public void PressResetButton()
    {
        if(timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
        textMeshPro.text = "00:00:00";
    }

    IEnumerator _StartTimerCoroutine()
    {
        while (true)
        {

            TimeSpan currentTime = TimeSpan.Parse(textMeshPro.text);
            currentTime = currentTime.Add(TimeSpan.FromSeconds(1));

            textMeshPro.text = currentTime.ToString(@"hh\:mm\:ss");

            yield return new WaitForSeconds(1);
        }
    }
}
