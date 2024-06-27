using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public void CloseParent()
    {
        // Dapatkan referensi ke component Canvas dari objek parent
        var canvas = transform.parent.GetComponent<Canvas>();
        if (canvas != null)
        {
            // Nonaktifkan component Canvas
            canvas.enabled = false;
        }
    }
}