using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class updatePos : MonoBehaviour
{
    public GameObject g;
    Coroutine c;
    private manipulate m = new manipulate();
    public float delay = 0.00001f;
    public float x;
    public float y;
    public float z = 0.5f;
    double angleXPrev = 0;
    double angleYPrev = 0;
    Vector3 curPosition = new Vector3(0,0,0.4f);
    Vector3 positionDiff = new Vector3(0,0,0);
    Vector3 angleDeviation = new Vector3(0,0,0);


    // Start is called before the first frame update
    void Start()
    {
        c = StartCoroutine(CountUp());

    }

    private void Stop() {
        StopCoroutine(CountUp());
    }
    IEnumerator CountUp() {
        
        
        while (true) {
            // Debug.Log(Camera.main.transform.eulerAngles);
            // Debug.Log("windows" + g.GetComponent<Transform>().eulerAngles);
            // Debug.Log(m.getMode());
            if (m.getMode()) {
                Vector3 angles = Camera.main.transform.eulerAngles;
            
                // let the screen always face with the camera(user)
                g.GetComponent<Transform>().eulerAngles = Camera.main.transform.eulerAngles;
                // converting value to radians
                double angleX = (angles[1] * (Math.PI)) / 180;
                double angleY = (angles[0] * (Math.PI)) / 180;

                // // if angleX update (rotate from X angle), we update in x version
                // if (angleXPrev - angleX > 0.01) {
                //     g.GetComponent<Transform>().position = Camera.main.transform.position + new Vector3(z * (float)(Math.Sin(angleX)), -z * (float)(Math.Sin(angleY)), z * (float)(Math.Cos(angleX)));
                //     angleXPrev = angleX;
                // }
                // else {
                //     g.GetComponent<Transform>().position = Camera.main.transform.position + new Vector3(z * (float)(Math.Sin(angleX)), -z * (float)(Math.Sin(angleY)), z * (float)(Math.Cos(angleY)));
                //     angleYPrev = angleY;
                // }
                // Debug.Log("y" + Math.Sin(angleY) + " " + angles[0]);
                // Debug.Log("z" + z - (float)(a * Math.Tan(angleX)));
                
                // g.GetComponent<Transform>().position = Camera.main.transform.position + new Vector3((z + positionDiff[0]) * (float)(Math.Sin(angleX)) + positionDiff[0], (-z - positionDiff[1]) * (float)(Math.Sin(angleY)) - positionDiff[1], z * (float)(Math.Cos(angleX + angleY)));
                // z = curPosition[2];
                g.GetComponent<Transform>().position = Camera.main.transform.position + new Vector3((z) * (float)(Math.Sin(angleX + angleDeviation[0])), (-z) * (float)(Math.Sin(angleY - angleDeviation[1])), z * (float)(Math.Cos(angleX + angleY)));
                // g.GetComponent<Transform>().position = Camera.main.transform.position + new Vector3(z * (float)(Math.Sin(angleX)) + positionDiff[0], -z * (float)(Math.Sin(angleY) - positionDiff[1]), z * (float)(Math.Cos(angleX)));
                
                // position before manipulation
                // curPosition = Camera.main.transform.position;
                // g.GetComponent<Transform>().position = Camera.main.transform.position + new Vector3(z * (float)(Math.Sin(angleX)), -z * (float)(Math.Sin(angleY)), z * (float)(Math.Cos(angleY)));

                // Debug.Log(g.GetComponent<Transform>().position);
                // Debug.Log((Math.Sin(angleY)) + " " + angles[0] + " " + (-z) * (float)(Math.Sin(angleY)));

                // g.GetComponent<Transform>().rotation = Camera.main.transform.rotation;
                
                
            }
            else {
                // if user is manipulating the window, get the diff between new position and the position of camera
                positionDiff = g.GetComponent<Transform>().position - Camera.main.transform.position;
                // 0 - 0.7 radian = (0 - 40 degree)
                // Calculate the angle deviation between camera and window
                float deviationX = (float)Math.Asin(positionDiff[0] / 0.5f);
                float deviationY = (float)Math.Asin(positionDiff[1] / 0.5f);
                Debug.Log(deviationX);
                // Set bounds, user is not allowed to move the window out of bound
                if (deviationX > 1.4f || Double.IsNaN(deviationX)) deviationX = 0.7f;
                if (deviationX < -1.4f || Double.IsNaN(deviationX)) deviationX = -0.7f;
                if (deviationY > 1.4f || Double.IsNaN(deviationY)) deviationY = 0.7f;
                if (deviationY < -1.4f || Double.IsNaN(deviationY)) deviationY = -0.7f;
                angleDeviation[0] = deviationX;
                angleDeviation[1] = deviationY;
                

            }
            yield return new WaitForSeconds(delay);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
