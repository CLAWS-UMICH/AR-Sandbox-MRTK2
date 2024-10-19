using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class VitalsController : MonoBehaviour
{
    private Subscription<VitalsUpdatedEvent> vitalsUpdatedEvent;
    TextMeshPro heartRateText;
    TextMeshPro bloodPressureText;
    TextMeshPro oxygenLevelText;
    TextMeshPro suitTempText;
    GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        vitalsUpdatedEvent = EventBus.Subscribe<VitalsUpdatedEvent>(OnVitalsUpdatedEvent);
        screen = GameObject.Find("screen");
        heartRateText = screen.transform.Find("heartRate").gameObject.GetComponent<TextMeshPro>();
        bloodPressureText = screen.transform.Find("bloodPressure").gameObject.GetComponent<TextMeshPro>();
        oxygenLevelText = screen.transform.Find("oxygenLevel").gameObject.GetComponent<TextMeshPro>();
        suitTempText = screen.transform.Find("suitTemp").gameObject.GetComponent<TextMeshPro>();
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
        Vitals vitals = e.vitals; 
        // Update the UI to reflect the new vitals values
        heartRateText.text = "Heart Rate: " + vitals.heart_rate;
        bloodPressureText.text = "Blood Pressure: " + vitals.blood_pressure;
        oxygenLevelText.text = "Oxygen Level: " + vitals.oxygen;
        suitTempText.text = "Suit Temp: " + vitals.suit_temp;

    }
}