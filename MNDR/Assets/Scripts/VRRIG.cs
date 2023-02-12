using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MapTransformed 
{
    public Transform vrTarget;
    public Transform ikTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void VRMapped()
    {
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRIG : MonoBehaviour
{
   [SerializeField]  private MapTransformed head;
    [SerializeField] private MapTransformed leftHand;

    [SerializeField] private MapTransformed rightHand;

    [SerializeField] private float turnSmoothness;

    [SerializeField] Transform ikHead;

    [SerializeField] Vector3 headBodyOffset;


    private void Update()
    {
        transform.position = ikHead.position + headBodyOffset;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(ikHead.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness);
        
        head.VRMapped();
        leftHand.VRMapped();
        rightHand.VRMapped();
    }

}

