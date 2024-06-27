using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public GameObject[] children;
    private Vector3 previousScale;

    private void Start()
    {
        // Store the initial scale of the parent GameObject
        previousScale = transform.localScale;
    }

    private void Update()
    {
        // Check if the scale has changed
        if (transform.localScale != previousScale)
        {
            // Reset the Trail Renderer components on the children
            foreach (GameObject child in children)
            {
                TrailRenderer trailRenderer = child.GetComponent<TrailRenderer>();
                if (trailRenderer != null)
                {
                    trailRenderer.Clear();
                    trailRenderer.enabled = false;
                }
            }
        }
        else
        {
            // Enable the Trail Renderer components on the children
            foreach (GameObject child in children)
            {
                TrailRenderer trailRenderer = child.GetComponent<TrailRenderer>();
                if (trailRenderer != null)
                {
                    trailRenderer.enabled = true;
                }
            }
        }

        // Store the current scale of the parent GameObject
        previousScale = transform.localScale;
    }

   
}