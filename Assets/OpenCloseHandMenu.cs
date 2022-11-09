using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseHandMenu : MonoBehaviour
{
    public GameObject handMenu;

    public void Click() {

        handMenu.SetActive(true);
        // if (handMenu.activeInHierarchy == true) {
        //     handMenu.SetActive(false);
        // }
        // else {
        //     handMenu.SetActive(true);
        // }
    }

}
