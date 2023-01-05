using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KritiButtonTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private IEnumerator coroutine;
    public GameObject panel;
    public GameObject panel2;

    public AudioClip clip;
    bool active = false;
   
    void Start()
    {
        
    }
    public void startButton(){
        coroutine = UpdateTime();
        StartCoroutine(coroutine);
    }

    public void endButton(){
        StopCoroutine(coroutine);
    }
    

    private IEnumerator UpdateTime(){
        while (true){
            yield return new WaitForSeconds(2);
            if(active){
                active = false;
            }
            else{
                active = true;
            }
            panel.SetActive(active);
            panel2.SetActive(active);
            Debug.Log("hi");
            gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
