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
        rootObject.position = transform.position + headBodyOffset;
        rootObject.forward = Vector3.ProjectOnPlane(followObject.up, Vector3.up).normalized;

        transform.position = followObject.TransformPoint(positionOffset);
        transform.rotation = followObject.rotation * Quaternion.Euler(rotationOffset);
    }
}
