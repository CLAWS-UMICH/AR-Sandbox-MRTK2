using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Class1
{
    public int classId;
}

public class ScriptingTutorial1 : MonoBehaviour
{
    [SerializeField] private int _var1;
    [SerializeField] private double _var2;
    [SerializeField] private float _var3;
    [SerializeField] private bool _var4;

    public int Var1 { 
        get
        {
            return _var1;
        } 
    } 
    public double Var2
    {
        get
        {
            return _var2;
        }
        set 
        {
            _var2 = value;
        }
    } 
    public float Var3 { 
        get {
            return _var3;
        }
    }
    public bool Var4 { 
        get
        {
            return _var4;
        }
    } 

    [SerializeField] private Class1 ClassInstance;

    private void Start()
    {
        // _var1 = 10;
        // _var2 = 3.14;
        // _var3 = 9.99f;
        // _var4 = true;

        ClassInstance = new Class1();
        ClassInstance.classId = 3;
    }
    public void SayHi()
    {
        Debug.Log(Var1 + " " + Var2 + " " + Var3 + " " + Var4 + " " + ClassInstance.classId);
    }

       

}
