using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add new Screens to the Enum
[System.Serializable]
public enum Screens
{
    Red,
    Blue,
    Green,
}

public class StateMachine : MonoBehaviour
{

    public Screens CurrScreen = Screens.Blue;
    private Subscription<ScreenChangedEvent> screenChangedSubscription; // Store the subscription

    private void Start()
    {
        screenChangedSubscription = EventBus.Subscribe<ScreenChangedEvent>(SwitchScreen);
    }

    private void OnDestroy()
    {
        // Unsubscribe when the script is destroyed
        if (screenChangedSubscription != null)
        {
            EventBus.Unsubscribe(screenChangedSubscription);
        }
    }

    public void SwitchScreen(ScreenChangedEvent e)
    {
        Debug.Log(CurrScreen.ToString() + " -> " + e.Screen.ToString());
        CurrScreen = e.Screen;
    }

    [ContextMenu("CloseScreen")]
    public void CloseScreen()
    {
        EventBus.Publish(new CloseEvent(CurrScreen));
    }

    [ContextMenu("CloseAll")]
    public void CloseAll()
    {
        EventBus.Publish(new CloseEvent(Screens.Red));
        EventBus.Publish(new CloseEvent(Screens.Green));
    }
}

