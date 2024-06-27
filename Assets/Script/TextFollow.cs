using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFollow : MonoBehaviour
{
    public Camera camerafollow;
    private Transform objectTransform;
    private Transform textTransform;

    void Start()
    {
        objectTransform = transform.parent;
        textTransform = transform;
    }

void Update()
{
    if (camerafollow != null)
    {
        Vector3 lookDirection = camerafollow.transform.position - textTransform.position;
        lookDirection.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        rotation.x = -rotation.x;
        textTransform.rotation = rotation;
    }
}




}