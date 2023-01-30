using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
