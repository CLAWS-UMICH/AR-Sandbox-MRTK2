using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public int randomNunber1 = 0;

    [SerializeField] private int _randomNumber2 = 100;
    public int RandomNumber2
    {
        get
        {
            return _randomNumber2;
        }
        set
        {
            if (value < 0)
            {
                _randomNumber2 = 0;
            }
        }
    }

    private void Start()
    {
       
    }
}
