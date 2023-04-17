using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script animates the player's legs as the player moves around.
// It tries to procedurally generate animations 
// We found through testing that users got sick when looking down at the legs moving which aren't theirs, so we stopped using it.

public class IKFootSolver : MonoBehaviour
{
    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private Transform body;
    [SerializeField] IKFootSolver otherFoot;
    [SerializeField] private float speed = 5, stepDestance = .3f, stepLength = .3f, stepHeight = .3f;
    [SerializeField] private Vector3 footPosOffset, footRotOffset;

    private float _footSpacing, _lerp;
    private Vector3 _oldPos, _currentPos, _newPos;
    private Vector3 _oldNorm, _currentNorm, _newNorm;

    // Start is called before the first frame update
    void Start()
    {
        _footSpacing = transform.localPosition.x;
        _currentPos = _newPos = _oldPos = transform.position;
        _currentNorm = _newNorm = _oldNorm = transform.up;
        _lerp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _currentPos + footPosOffset;
        transform.rotation = Quaternion.LookRotation(_currentNorm) * Quaternion.Euler(footRotOffset);

        Ray ray = new Ray(origin: body.position + (body.right * _footSpacing) + (Vector3.up * 2), direction: Vector3.down);

        if(Physics.Raycast(ray, out RaycastHit hit, maxDistance:10, terrainLayer.value))
        {
            if(Vector3.Distance(a:_newPos, b:hit.point) > stepDestance && !otherFoot.IsMoving() && !IsMoving())
            {
                _lerp = 0;
                int direction = body.InverseTransformPoint(hit.point).z > body.InverseTransformPoint(_newPos).z ? 1 : -1;
                _newPos = hit.point + (body.forward * (direction * stepLength) );
                _newNorm = hit.normal;
            }
        }

        if(_lerp < 1)
        {
            Vector3 tempPos = Vector3.Lerp(a: _oldPos, b: _newPos, _lerp);
            tempPos.y += Mathf.Sin(f: _lerp * Mathf.PI) * stepHeight;

            _currentPos = tempPos;
            _currentNorm = Vector3.Lerp(a: _oldNorm, b: _newNorm, _lerp);
            _lerp += Time.deltaTime * speed;
        }
        else 
        {
            _oldPos = _newPos;
            _oldNorm = _newNorm;
        }
    }
    public bool IsMoving()
    {
        return _lerp < 1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_newPos, radius:0.1f);
    }
}
