using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MessagingController : MonoBehaviour
{

    private Subscription<MessagesDeletedEvent> messagesDeletedEvent;
    private Subscription<MessagesEditedEvent> messagesEditedEvent;
    private Subscription<MessagesAddedEvent> messagesAddedEvent;

    private TextMeshPro msgText;
    private TextMeshPro IDText;
    private TextMeshPro fromText;
    private TextMeshPro toText;
    GameObject parentObject; //prefab MessageObject
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        messagesDeletedEvent = EventBus.Subscribe<MessagesDeletedEvent>(OnMessagesDeleted);
        messagesEditedEvent = EventBus.Subscribe<MessagesEditedEvent>(OnMessagesEdited);
        messagesAddedEvent = EventBus.Subscribe<MessagesAddedEvent>(OnMessagesAdded);

        parentObject = GameObject.Find("MessageObject");
        msgText = parentObject.transform.Find("DisplayedMessage").gameObject.GetComponent<TextMeshPro>();
        IDText = parentObject.transform.Find("ID").gameObject.GetComponent<TextMeshPro>();
        fromText = parentObject.transform.Find("from").gameObject.GetComponent<TextMeshPro>();
        toText = parentObject.transform.Find("sentTo").gameObject.GetComponent<TextMeshPro>();
        msgText.text = "no current message";
        IDText.text = "ID: N/A";

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
        foreach (Message msg in newAddedMessages)
        {
            IDText.text = "ID: " + msg.id.ToString();
            msgText.text = msg.message;
            fromText.text = msg.from.ToString();
            toText.text = msg.sent_to.ToString();
        }
    }
}
