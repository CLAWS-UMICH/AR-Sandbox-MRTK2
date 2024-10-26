using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using UnityEngine.UI;
public class ClockController : MonoBehaviour
{

    TextMeshPro clockText;
    TextMeshPro text;
    private Coroutine clockCoroutine;
    private Boolean isEastern = false;
    private Boolean isCentral = false;
    private Boolean isPacific = false;


    // Start is called before the first frame update
    void Start()
    {
        clockText = GameObject.Find("ClockText").GetComponent<TextMeshPro>();
        text = GameObject.Find("MenuTitleText").GetComponent<TextMeshPro>();
    }

    void OnDisable()
    {
        if (clockCoroutine != null)
        {
            StopCoroutine(clockCoroutine);
            clockCoroutine = null;
        }
        text.text = "Select";
        clockText.text = "00:00:00 PM";
    }

    public void EasternStart()
    {
        if (clockCoroutine == null)
            clockCoroutine = StartCoroutine(Eastern());
        if (clockCoroutine != null && !isEastern)
        {
            StopCoroutine(clockCoroutine);
            clockCoroutine = StartCoroutine(Eastern());
        }
        text.text = "Eastern Time";
        isEastern = true;
        isCentral = false;
        isPacific = false;
    }

    public void CentralStart()
    {
        if (clockCoroutine == null)
            clockCoroutine = StartCoroutine(Central());
        if (clockCoroutine != null && !isCentral)
        {
            StopCoroutine(clockCoroutine);
            clockCoroutine = StartCoroutine(Central());
        }
        text.text = "Central Time";
        isCentral = true;
        isEastern = false;
        isPacific = false;
    }

    public void PacificStart()
    {
        if (clockCoroutine == null)
            clockCoroutine = StartCoroutine(Pacific());
        if (clockCoroutine != null && !isPacific)
        {
            StopCoroutine(clockCoroutine);
            clockCoroutine = StartCoroutine(Pacific());
        }
        text.text = "Pacific Time";
        isPacific = true;
        isCentral = false;
        isEastern = false;
    }

    private IEnumerator Eastern()
    {
        while (true)
        {
            System.DateTime now = System.TimeZoneInfo.ConvertTimeBySystemTimeZoneId(System.DateTime.Now, "Eastern Standard Time");
            clockText.text = now.ToString("hh:mm:ss tt");
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator Central() {
        while (true)
        {
            System.DateTime now = System.TimeZoneInfo.ConvertTimeBySystemTimeZoneId(System.DateTime.Now, "Central Standard Time");
            clockText.text = now.ToString("hh:mm:ss tt");
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator Pacific() {
        while (true)
        {
            System.DateTime now = System.TimeZoneInfo.ConvertTimeBySystemTimeZoneId(System.DateTime.Now, "Pacific Standard Time");
            clockText.text = now.ToString("hh:mm:ss tt");
            yield return new WaitForSeconds(1);
        }
    }
    
}
