using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Transform rootObject, followObject;
    public Vector3 positionOffset, rotationOffset, headBodyOffset;

    private Vector3 _headBodyOffset;

    private void Start()
    {
        _headBodyOffset = rootObject.position - followObject.position;
    }
    private void LateUpdate()
    {
        // setting the position of root object
        rootObject.position = transform.position + headBodyOffset;

        // setting the forward transform to project a vector on a plane
        rootObject.forward = Vector3.ProjectOnPlane(followObject.up, Vector3.up).normalized;

        // setting postions and rotation for the object this script is attached to
        transform.position = followObject.TransformPoint(positionOffset);
        transform.rotation = followObject.rotation * Quaternion.Euler(rotationOffset);
    }
}
