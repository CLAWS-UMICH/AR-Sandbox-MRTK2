using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadCollision : MonoBehaviour
{

    [SerializeField] BreadCrumbMain BreadCrumbMainInstance;

    // On Trigger of crumb it destroys the object
    private void OnTriggerEnter(Collider other)
    {
        // Checks if collision is the correct tag of object
        if (other.gameObject.tag == "crumb")
        {
            //BreadCrumbMainInstance.CollisionTrue = other.gameObject; (used if we want to use other script to destroy)
            Destroy(other.gameObject);
        }
    }
}
