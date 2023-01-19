using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenSize : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] TextMeshPro textMeshPro;
    public GameObject screen;
    private Vector3 si, so, vi, vo;
    private float x, y;
    // Start is called before the first frame update
    void Start()
    {
        x = 1f;
        y = 1f;
        
    }

    public void sideIn() {
        si = new Vector3(-0.1f, 0, 0);
        panel.transform.localScale += si;
        x -= .1f;
        textMeshPro.text = "X Scale: " + x;
    }

    public void sideOut() {
        so = new Vector3(0.1f, 0, 0);
        panel.transform.localScale += so;
        x += .1f;
        textMeshPro.text = "X Scale: " + x;
    }

    public void vertIn() {
        vi = new Vector3(0, -0.1f, 0);
        panel.transform.localScale += vi;
        y -= .1f;
        textMeshPro.text = "Y Scale: " + y;
    }

    public void vertOut() {
        vo = new Vector3(0, 0.1f, 0);
        panel.transform.localScale += vo;
        y += .1f;
        textMeshPro.text = "Y Scale: " + y;
    }

    public void yUp() {
        vo = new Vector3(0, 0.1f, 0);
        panel.transform.localScale += vo;
        y += .1f;
        textMeshPro.text = "Y Pos: " + screen.transform.position.y;
    }

    public void yDown() {
        vo = new Vector3(0, -0.1f, 0);
        panel.transform.localPosition += vo;
        y += .1f;
        textMeshPro.text = "Y Pos: " + screen.transform.position.y;
    }
}
