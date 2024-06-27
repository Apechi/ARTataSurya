using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trails : MonoBehaviour
{
    public float minVertexDistance = 0.1f; // minimum distance between line vertices
    public float maxLineWidth = 0.1f; // maximum width of the line
    public float lineWidth; // current width of the line
    public Color lineColor = Color.white; // color of the line
    public int maxNumberOfPoints = 50; // maximum number of points in the line
    public bool useWorldSpace = true; // should the line be in world space or local space
    public bool useWorldRotation = false; // should the line use the game object's world rotation or local rotation

    private LineRenderer lineRenderer; // the line renderer component
    private List<Vector3> pointsList; // list of points in the line
    private float distanceMoved; // distance moved since the last line point was added
    private bool isPaused; // is the line trail paused
    private Quaternion previousRotation; // previous rotation of the game object

    // Use this for initialization
    void Start()
    {
        // get the line renderer component
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("LineTrail script requires a LineRenderer component.");
            enabled = false;
            return;
        }

        // create a new list of points for the line
        pointsList = new List<Vector3>();

        // set the line renderer's start width
        lineRenderer.startWidth = maxLineWidth;

        // set the line renderer's end width
        lineRenderer.endWidth = 0;

        // set the line renderer's material color
        lineRenderer.material.color = lineColor;

        // set the line renderer's use world space
        lineRenderer.useWorldSpace = useWorldSpace;

        // set the previous rotation to the current rotation
        previousRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // check if the line trail is paused
        if (isPaused)
        {
            return;
        }

        // check if the distance moved since the last line point was added is greater than the minimum distance between points
        if (distanceMoved > minVertexDistance)
        {
            // add a new point to the line
            AddLinePoint();
        }
        else
        {
            // update the line's width based on the distance moved
            UpdateLineWidth();
        }
    }

    // adds a new point to the line
    void AddLinePoint()
    {
        // reset the distance moved
        distanceMoved = 0;

        // check if the line renderer has too many points
        if (pointsList.Count > maxNumberOfPoints)
        {
            // remove the first point in the list
            pointsList.RemoveAt(0);

            // set the line renderer's position to the new list of points
            lineRenderer.positionCount = pointsList.Count;
    lineRenderer.SetPositions(pointsList.ToArray());
}
    }

// update the line's width based on the distance moved
void UpdateLineWidth()
{
    // calculate the current line width based on the distance moved and the maximum line width
    lineWidth = Mathf.Lerp(maxLineWidth, 0, distanceMoved / minVertexDistance);

    // set the line renderer's start width
    lineRenderer.startWidth = lineWidth;
}

// pause the line trail
public void Pause()
{
    // set isPaused to true
    isPaused = true;
}

// resume the line trail
public void Resume()
{
    // set isPaused to false
    isPaused = false;
}

// reset the line trail
public void Reset()
{
    // clear the points list
    pointsList.Clear();

    // set the line renderer's position count to 0
    lineRenderer.positionCount = 0;

    // reset the distance moved
    distanceMoved = 0;
}
}
