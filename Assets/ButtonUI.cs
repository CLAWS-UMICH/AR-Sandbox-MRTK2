using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "ButtonStart";

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
        Debug.Log("Button Clicked")
    }
}
