using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerGrounded : MonoBehaviour
{
    [SerializeField] private float slopeForce;
    //[SerializeField] private float slopeForceRayLength;
    private CharacterController charController;
    // Start is called before the first frame update
    void Start()
    {
        charController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnSlope())
        {
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);
        }
    }
    private bool OnSlope()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2))
            if (hit.normal != Vector3.up)
                return true;
        return false;
    }
}
