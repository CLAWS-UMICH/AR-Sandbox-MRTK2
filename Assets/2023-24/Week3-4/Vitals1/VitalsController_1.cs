using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VitalsController_1 : MonoBehaviour
{

    private Subscription<VitalsUpdatedEvent> vitalsUpdatedEvent;
    GameObject screen;
    TextMeshPro hr;
    TextMeshPro o2;
    TextMeshPro st;
    TextMeshPro bp;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        vitalsUpdatedEvent = EventBus.Subscribe<VitalsUpdatedEvent>(OnVitalsUpdatedEvent);

        screen = GameObject.Find("screen");
        hr = screen.transform.Find("Heart_rate").gameObject.GetComponent<TextMeshPro>();
        o2 = screen.transform.Find("Oxygen").gameObject.GetComponent<TextMeshPro>();
        st = screen.transform.Find("Suit_temp").gameObject.GetComponent<TextMeshPro>();
        bp = screen.transform.Find("Blood_pressure").gameObject.GetComponent<TextMeshPro>();
    }

    void OnDestroy()
    {
        // Unsubscribe when the script is destroyed
        if (vitalsUpdatedEvent != null)
        {
            EventBus.Unsubscribe(vitalsUpdatedEvent);
        }

    }

    private void OnVitalsUpdatedEvent(VitalsUpdatedEvent e)
    {
        Debug.Log("Test");
        Vitals vitals = e.vitals; 
        hr.text = vitals.heart_rate.ToString();
        o2.text = vitals.oxygen.ToString();
        st.text = vitals.suit_temp.ToString();
        bp.text = vitals.blood_pressure.ToString();
        
        // Update the UI to reflect the new vitals values
    }

}
