using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptingTutorial2 : MonoBehaviour
{
    private static ScriptingTutorial2 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] int count;
    [SerializeField] float delay;
    [SerializeField] TextMeshPro tmp;

    Coroutine c;

    private void _StartCount()
    {
        c = StartCoroutine(CountUp());
    }

    public static void StartCount()
    {
        instance._StartCount();
    }

    public static void StopCount()
    {
        Debug.Log("Called");
        instance.StopCoroutine(instance.c);
    }

    private IEnumerator CountUp()
    {
        while (true)
        {
            count++;
            tmp.text = count.ToString();
            yield return new WaitForSeconds(delay);
        }
    }

    new public static string ToString()
    {
        return instance.count.ToString() + " " + instance.delay.ToString();
    }

}
