using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    int count = 0;
    GameObject screen;
    TextMeshPro textMeshPro;
    private IEnumerator timerCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Screen");
        textMeshPro = screen.transform.Find("Text").gameObject.GetComponent<TextMeshPro>();
        textMeshPro.text = "HH:MM:SS";
        timerCoroutine = _UpdateTimer();
}
    public void StartTimer()
    {
       StartCoroutine(timerCoroutine);
    }
    public void StopTimer()
    {
       StopCoroutine(timerCoroutine);
    }
    public void ResetTimer()
    {
        StopCoroutine(timerCoroutine);
        count = 0;
        textMeshPro.text = count.ToString();
    }
    IEnumerator _UpdateTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            count++;
            UpdateUI();
        }
    }
    void UpdateUI()
    {
        textMeshPro.text = count.ToString();
    }

}
