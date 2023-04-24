using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
   // private Vector3 positionWithOffset;
   // private float distance;
   // private Quaternion rotationWithOffset;
   // private Quaternion q;

     public GameObject followObject;
    public float rotateSpeed = 100f;
    public float followSpeed = 30f;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    private Transform _followTarget;
    private Rigidbody _body;

    private void Start()
    {
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }
    private void Update()
    {
        PhysicsMove();
    }
    private void PhysicsMove()
    {
       var positionWithOffset = _followTarget.TransformPoint(positionOffset) ;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
       var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }
}
