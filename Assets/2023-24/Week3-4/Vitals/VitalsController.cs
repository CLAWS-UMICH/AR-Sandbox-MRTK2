using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalsController : MonoBehaviour
{

    private Subscription<VitalsUpdatedEvent> vitalsUpdatedEvent;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        vitalsUpdatedEvent = EventBus.Subscribe<VitalsUpdatedEvent>(OnVitalsUpdatedEvent);
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
    }

}
