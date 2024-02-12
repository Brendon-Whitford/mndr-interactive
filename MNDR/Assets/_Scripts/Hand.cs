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
        //setting the transform of the followObject GameObject
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();

        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;

        // setting the Rigibody mass
        _body.mass = 20f;

        // setting Rigidbody positon and rotation = to followTarget position and rotation
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    private void Update()
    {
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        // aniamting the movemnets of the hand with code
       var positionWithOffset = _followTarget.TransformPoint(positionOffset) ;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
       var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }
}
