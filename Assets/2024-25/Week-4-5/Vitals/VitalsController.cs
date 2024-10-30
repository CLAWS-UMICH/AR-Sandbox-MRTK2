using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class VitalsController : MonoBehaviour
{
    private Subscription<VitalsUpdatedEvent> vitalsUpdatedEvent;
    TextMeshPro heartRateText;
    TextMeshPro bloodPressureText;
    TextMeshPro oxygenLevelText;
    TextMeshPro suitTempText;
    GameObject screen;

    GameObject canvas;
    public Button heartRateButton;
    public Button bloodPressureButton;
    public Button oxygenLevelButton;
    public Button suitTemptButton;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        vitalsUpdatedEvent = EventBus.Subscribe<VitalsUpdatedEvent>(OnVitalsUpdatedEvent);
        Debug.Log("subscribed");

        screen = GameObject.Find("screen");
        heartRateText = screen.transform.Find("heartRate").gameObject.GetComponent<TextMeshPro>();
        bloodPressureText = screen.transform.Find("bloodPressure").gameObject.GetComponent<TextMeshPro>();
        oxygenLevelText = screen.transform.Find("oxygenLevel").gameObject.GetComponent<TextMeshPro>();
        suitTempText = screen.transform.Find("suitTemp").gameObject.GetComponent<TextMeshPro>();

        canvas = GameObject.Find("Canvas");
        heartRateButton = canvas.transform.Find("LogHeart").gameObject.GetComponent<Button>();
        bloodPressureButton = canvas.transform.Find("LogOx").gameObject.GetComponent<Button>();
        oxygenLevelButton = canvas.transform.Find("LogSuit").gameObject.GetComponent<Button>();
        suitTemptButton = canvas.transform.Find("LogBP").gameObject.GetComponent<Button>();

        heartRateButton.onClick.AddListener(LogRate);
        bloodPressureButton.onClick.AddListener(LogPressure);
        oxygenLevelButton.onClick.AddListener(LogOxygen);
        suitTemptButton.onClick.AddListener(LogTempt);

        // Added click listeners that call the parameter function


        Debug.Log("connected");

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
        Debug.Log("vitals received");

        Vitals vitals = e.vitals; 
        // Update the UI to reflect the new vitals values
        heartRateText.text = "Heart Rate: " + vitals.heart_rate;
        bloodPressureText.text = "Blood Pressure: " + vitals.blood_pressure;
        oxygenLevelText.text = "Oxygen Level: " + vitals.oxygen;
        suitTempText.text = "Suit Temp: " + vitals.suit_temp;
    }

    /* If you're reading this, just know that the python server did not want to communicate with Unity whatsoever.
    This was one of the most mind numbing experiences I've ever had in my life. I told my partner I would be done by 9:00PM, but it is
    currently 10:56PM. I think it was a problem with the firewall, because I had to go into my Windows environment settings just to
    get the python server started. Holy crap. I spent so much time trying to fix it. You'll see random print and debug statements
    all over the place because that was me trying to figure out what was going on. What a disaster.*/

    public void LogRate() {
        Debug.Log(heartRateText);
    }
    public void LogPressure() {
        Debug.Log(bloodPressureText);
    }
    public void LogOxygen() {
        Debug.Log(oxygenLevelText);
    }
    public void LogTempt() {
        Debug.Log(suitTempText);
    }

    // Logs the current value for each vital in the console
}