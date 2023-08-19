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
    [SerializeField] private float spacing = 1f; // Distance between gameobjects
    [SerializeField] private int buttonsEnabledCount = 3; // Number of gameobjects to scroll per button press
    [SerializeField] private LayoutType layoutType; // Type of layout

    private List<Transform> allButtons = new List<Transform>(); // List to store all buttons

    private int top = -1; // Index of the topmost visible button
    private int bottom = -1; // Index of the bottommost visible button

    public void Start()
    {
        FindIndexes(); // Initializes the top and down indexes
        EnableButtons(); // Enable initial buttons
        CollectAllButtons(); // Collect all buttons into the list
        CorrectLocations(); // Adjust enabled buttons' positions
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
    public void CorrectLocations()
    {
        Transform parentTransform = transform;

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
                yOffset = (i - top) * -spacing; // Adjust y-offset for vertical layout
            }

            Vector3 newPosition = parentTransform.position + new Vector3(xOffset, yOffset, 0f);
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

    // Activates buttons from start -> stop range
    private void Activate(int start, int stop)
    {
        for (int i = start; i < stop + 1; i++)
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


}