using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptingTutorial3 : MonoBehaviour
{
    bool counting = false;

    public void ButtonPressed()
    {
        if (counting)
        {
            ScriptingTutorial2.StopCount();
        }
        else
        {
            ScriptingTutorial2.StartCount();
        }
        counting = !counting;
    }
}
