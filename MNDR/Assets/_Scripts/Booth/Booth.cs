using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * Created By Carson McMahan || 01/26/2024
 * This script was built for sitting the player at a booth inside of the hub world.
 * When the scene starts the player is sitting.
 * If the player points the right controller at the groud and presses A, then they can walk around.
 * If the player points the right controller at the booth and presses A, they will "sit" at the booth.
 */

public class Booth : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform rightControllerTransform;
    [SerializeField] private ActionBasedContinuousMoveProvider XRMovement;

    [Header("Booth Transforms")]
    [Tooltip("This transform will be located in the Booth object as a child.")]
    [SerializeField] private Transform boothSittingTransform;
    [SerializeField] private Transform exitTransform;
    //[SerializeField] private Transform leftTransform;

    [Header("Interaction References")]
    [SerializeField] private LayerMask boothLayerMask;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float interactDistance;

    bool isSitting;

    private void Start()
    {
        // player starts sitting at the booth
        MovePlayer(boothSittingTransform);
        XRMovement.enabled = false;

        isSitting = true; 
    }

    private void Update()
    {
        if(Input.GetButtonDown("RightController_A"))
        {
            // creating the point to shoot the ray cast
            Ray rightControllerRay = new(rightControllerTransform.position, rightControllerTransform.forward);

            Debug.Log("Pressed");

            if(isSitting == true)
            {
                // shooting the raycast
                if (Physics.Raycast(rightControllerRay, out RaycastHit hit, interactDistance, groundLayerMask))
                {
                    // distance between the hit position and a transform (right or left transform)

                    //float rightDistance = Vector3.Distance(hit.point, exitTransform.position);
                    //float leftDistance = Vector3.Distance(hit.point, leftTransform.position);
                    // enabling movement & setting isSitting to false

                    MovePlayer(exitTransform);

                    XRMovement.enabled = true;
                    isSitting = false;

                    //if (rightDistance < leftDistance)
                    //{
                    //    MovePlayer(exitTransform);

                    //    Debug.Log("Leaving booth: " + exitTransform);
                    //}
                    //else
                    //{
                    //    MovePlayer(leftTransform);

                    //    Debug.Log("Leaving booth: " + leftTransform);
                    //}
                }
            }
            else
            {
                // shooting the raycast
                if (Physics.Raycast(rightControllerRay, interactDistance, boothLayerMask))
                {
                    // calling MovePlayer and disabling the movement script
                    MovePlayer(boothSittingTransform);
                    XRMovement.enabled = false;

                    isSitting = true;

                    Debug.Log("Hit Booth");
                }
            }
        }
    }

    private void MovePlayer(Transform transform)
    {
        // setting the player position and rotation to the parameter
        playerTransform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
