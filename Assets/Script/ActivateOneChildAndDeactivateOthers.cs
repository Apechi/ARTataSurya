using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOneChildAndDeactivateOthers : MonoBehaviour
{
    // drag and drop the object you want to activate into this field in the Inspector
    public GameObject objectToActivate;

    // this function will be called when the button is pressed
    public void ButtonPressed()
    {
        // deactivate all children of this object
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        // activate the selected object
        objectToActivate.SetActive(true);
    }
}
