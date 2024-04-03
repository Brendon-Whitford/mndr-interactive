using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour
{
    [SerializeField] Transform XRCameraTransform;

    [SerializeField] GameObject waist;
    [SerializeField] float waistOffsetHeight;
    [SerializeField] float[] lookDownPauseRotationRange = new float[2] { 45, 90 };

    // Update is called once per frame
    void Update()
    {
        if (!CanSeeWaist()) UpdateWaistLocation();
    }

    bool CanSeeWaist()
    {
        if (XRCameraTransform.eulerAngles.x > lookDownPauseRotationRange[0] && XRCameraTransform.eulerAngles.x < lookDownPauseRotationRange[1])
        {
            return true;
        }
        else return false;
    }

    void UpdateWaistLocation()
    {
        // Translate position to match camera X, Y - offset, Z
        float newYPosition = Mathf.Clamp(XRCameraTransform.position.y - waistOffsetHeight, 0.1f, XRCameraTransform.position.y);

        waist.transform.position = new Vector3(XRCameraTransform.position.x, newYPosition, XRCameraTransform.position.z);
        // Rotate to match camera
        waist.transform.eulerAngles = new Vector3(waist.transform.eulerAngles.x, XRCameraTransform.eulerAngles.y, waist.transform.eulerAngles.z);
    }
}
