using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Buatkan variabel untuk menyimpan kecepatan rotasi
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotasi objek sebesar kecepatan rotasi setiap frame
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
