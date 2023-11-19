using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LayoutType
{
    Vertical,
    Horizontal
}

public class ScrollHandler : MonoBehaviour
{
    [SerializeField] private float spacing = 0.1f; // Distance between gameobjects
    [SerializeField] private int buttonsEnabledCount = 3; // Number of gameobjects to scroll per button press
    [SerializeField] private LayoutType layoutType; // Type of layout

    private List<Transform> allButtons = new List<Transform>(); // List to store all buttons

    private int top = -1; // Index of the topmost visible button
    private int bottom = -1; // Index of the bottommost visible button

    private void Start()
    {
        CollectAllButtons();
        Fix();
    }

    // Initializes the top and down indexes
    private void FindIndexes()
    {
        int numButtons = GetButtonCount();
        if (numButtons > 0)
        {
            top = 0;

            if (numButtons > buttonsEnabledCount)
            {
                bottom = buttonsEnabledCount - 1;
            }
            else
            {
                bottom = numButtons - 1;
            }
        }
    }

    // Gets the amount of buttons
    private int GetButtonCount()
    {
        return transform.childCount;
    }

    // Enables the correct number buttons at the start
    private void EnableButtons()
    {
        Transform parentTransform = transform;
        int count = 0;

        foreach (Transform child in parentTransform)
        {
            if (count < buttonsEnabledCount)
            {
                child.gameObject.SetActive(true); // Enable initial buttons
            }
            else
            {
                child.gameObject.SetActive(false); // Disable additional buttons
            }
            count++;
        }
    }

    // Adds all buttons to a list. Used in case of new buttons added in the middle of the run
    private void CollectAllButtons()
    {
        Transform parentTransform = transform;
        allButtons.Clear();

        foreach (Transform child in parentTransform)
        {
            allButtons.Add(child);
        }
    }

    // Move the top -> bottom indexed buttons to their correct locations based on the offset
    private void CorrectLocations()
    {
        Transform parentTransform = transform;
        if (allButtons.Count == 0)
        {
            return;
        }

        for (int i = top; i < bottom + 1; i++)
        {
            float xOffset = 0f;
            float yOffset = 0f;

            if (layoutType == LayoutType.Horizontal)
            {
                xOffset = (i - top) * spacing; // Adjust x-offset for horizontal layout
            }
            else
            {
                if (i == 0)
                {
                    yOffset = (i - top) * -spacing; // Adjust y-offset for vertical layout
                    // this is just 0
                }
                else
                {
                    yOffset = allButtons[i - 1].transform.position.y
                        - (allButtons[i - 1].GetComponent<BoxCollider>().size.y / 2
                            * allButtons[i - 1].transform.localScale.y) 
                        - (allButtons[i].GetComponent<BoxCollider>().size.y / 2
                            * allButtons[i].transform.localScale.y)
                        - spacing;
                    Debug.Log(yOffset);
                }
            }

            // Vector3 newPosition = parentTransform.position + new Vector3(xOffset, yOffset, 0f);
            Vector3 newPosition = new Vector3(xOffset, yOffset, 0f);
            allButtons[i].transform.position = newPosition; // Move each button to the new position
        }
    }

    private void Scroll(int direction)
    {
        if (direction > 0 && top - direction >= 0)
        {
            CollectAllButtons(); // Get all new buttons
            Deactivate(bottom - direction + 1, bottom); // Deactivate old buttons
            Activate(top - direction, top - 1); // Activate new buttons

            // Update new top/bottom indexes
            top -= direction;
            bottom -= direction;

            CorrectLocations(); // Re-adjust button positions
        }

        if (direction < 0 && bottom - direction < GetButtonCount())
        {
            CollectAllButtons(); // Get all new buttons
            Deactivate(top, top - direction - 1); // Deactivate old buttons
            Activate(bottom + 1, bottom - direction); // Activate new buttons

            // Update new top/bottom indexes
            top -= direction;
            bottom -= direction;

            CorrectLocations(); // Re-adjust button positions
        }
    }

    // Function to handle button deletion based on GameObject
    public void HandleButtonDeletion(GameObject deletedButton)
    {
        // Find the index of the deleted button
        int deletedIndex = allButtons.FindIndex(button => button.gameObject == deletedButton);

        if (deletedIndex >= 0)
        {
            // Destroy the deleted GameObject
            Destroy(deletedButton);

            // Remove the button at the deleted index
            RemoveButton(deletedIndex);

            // Update the scroll layout
            CorrectLocations();

        }
        else
        {
            Debug.LogWarning("Deleted button not found in the list.");
        }
    }

    // Removes a button at the specified index
    private void RemoveButton(int index)
    {
        if (index >= 0 && index < allButtons.Count)
        {
            allButtons.RemoveAt(index);

            // Update top and bottom indexes after button removal
            if (top >= index)
            {
                top = Mathf.Max(top - 1, 0);
            }

            if (bottom >= index)
            {
                bottom = Mathf.Max(bottom - 1, 0);
            }

            Activate(top, bottom);
        }
    }

    // Activates buttons from start -> stop range
    private void Activate(int start, int stop)
    {
        // Ensure that start and stop indices are within the valid range
        if (start < 0)
        {
            start = 0;
        }

        if (stop >= allButtons.Count)
        {
            stop = allButtons.Count - 1;
        }

        if (allButtons.Count == 0)
        {
            start = -1;
            stop = -1;
            return;
        }

        for (int i = start; i <= stop; i++)
        {
            allButtons[i].gameObject.SetActive(true);
        }
    }

    // Deactivates buttons from start -> stop range
    private void Deactivate(int start, int stop)
    {
        for (int i = start; i < stop + 1; i++)
        {
            allButtons[i].gameObject.SetActive(false);
        }
    }

    // Scrolls up/left
    public void ScrollUpOrLeft()
    {
        Scroll(1);
    }

    // Scrolls up/right
    public void ScrollDownOrRight()
    {
        Scroll(-1);
    }

    [ContextMenu("Func FixLayout")]
    public void Fix()
    {
        CollectAllButtons();
        if (allButtons.Count > 0)
        {
            FindIndexes(); // Initializes the top and down indexes
            EnableButtons(); // Enable initial buttons
            CollectAllButtons(); // Collect all buttons into the list
            CorrectLocations(); // Adjust enabled buttons' positions
        }
    }

    // Function to handle button deletion based on GameObject
    public GameObject HandleAddingButton(GameObject newButton)
    {
        GameObject button = Instantiate(newButton, transform);
        Fix();

        return button;
    }


}
