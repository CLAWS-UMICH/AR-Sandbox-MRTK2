using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionChecklist : MonoBehaviour
{
    [SerializeField] TaskBox taskBox;

    public void AddTask()
    {
        Instantiate(taskBox, gameObject.transform);
    }
}
