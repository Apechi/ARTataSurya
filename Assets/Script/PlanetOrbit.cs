using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public GameObject sun; // the sun game object
    public float orbitSpeed = 1f; // the speed at which the planet should orbit the sun

    void Update()
    {
        // rotate the planet around the sun
        transform.RotateAround(sun.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);

        // rotate the planet around its own axis slowly on the y-axis
        transform.Rotate(Vector3.up, orbitSpeed * Time.deltaTime * 0.1f);
    }
}
