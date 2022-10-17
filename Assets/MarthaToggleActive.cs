using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarthaToggleActive : MonoBehaviour
{
    public CubeScript cubeSript;

    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        int randomNumber1 = cubeSript.randomNunber1;
        int randomNumber2 = cubeSript.RandomNumber2;
        cubeSript.RandomNumber2 = -19;
        Debug.Log(cubeSript.RandomNumber2);
    }
}
