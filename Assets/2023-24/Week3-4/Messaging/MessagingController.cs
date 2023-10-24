using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessagingController : MonoBehaviour
{

    private Subscription<MessagesDeletedEvent> messagesDeletedEvent;
    private Subscription<MessagesEditedEvent> messagesEditedEvent;
    private Subscription<MessagesAddedEvent> messagesAddedEvent;

    private TextMeshPro msgText;
    GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        messagesDeletedEvent = EventBus.Subscribe<MessagesDeletedEvent>(OnMessagesDeleted);
        messagesEditedEvent = EventBus.Subscribe<MessagesEditedEvent>(OnMessagesEdited);
        messagesAddedEvent = EventBus.Subscribe<MessagesAddedEvent>(OnMessagesAdded);

        parentObject = GameObject.Find("MessageObject");
        msgText = parentObject.transform.Find("DisplayedMessage").gameObject.GetComponent<TextMeshPro>();
        msgText.text = "no current message";
    }

    void OnDestroy()
    {
        // Unsubscribe when the script is destroyed
        if (messagesDeletedEvent != null)
        {
            EventBus.Unsubscribe(messagesDeletedEvent);
        }
        if (messagesEditedEvent != null)
        {
            EventBus.Unsubscribe(messagesEditedEvent);
        }
        if (messagesAddedEvent != null)
        {
            EventBus.Unsubscribe(messagesAddedEvent);
        }
    }

    private void OnMessagesDeleted(MessagesDeletedEvent e)
    {
        //Debug.Log("Deleted");
        List<Message> deletedMessages = e.DeletedMessages; // Which messages were deleted (Look at their id's)
        // Update the UI to reflect the deleted messages
    }

    private void OnMessagesEdited(MessagesEditedEvent e)
    {
        //Debug.Log("Edited");
        List<Message> editedMessages = e.EditedMessages; // Which messages were edited (Look at their id's)
        // Update the UI to reflect the edited messages
    }

    private void OnMessagesAdded(MessagesAddedEvent e)
    {
        //Debug.Log("Added");
        List<Message> newAddedMessages = e.NewAddedMessages; // Which messages are new
        msgText.text = newAddedMessages[0].message;
        // Update the UI to reflect the new messages
    }
}
