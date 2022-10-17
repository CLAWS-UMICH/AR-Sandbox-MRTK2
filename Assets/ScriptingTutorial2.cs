using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptingTutorial2 : MonoBehaviour
{
    [SerializeField] ScriptingTutorial1 ScriptingTutorial1Instance;

    public void PrintVar1()
    {
        Debug.Log(ScriptingTutorial1Instance.Var1);
    }
}
