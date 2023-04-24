using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Orbit an object around another object (pivotpoint)
// I found this useful for audio applications.
// elias@willerup.com

public class OrbitAroundObject : MonoBehaviour
{
    [Header("Make sure any audio source is set to 3D.")]

    public GameObject pivotPoint;
    public float rotateSpeed = 10f;

    void FixedUpdate()
    {
        transform.RotateAround(pivotPoint.transform.position, new Vector3(0, 1, 0), rotateSpeed);
    }
}
