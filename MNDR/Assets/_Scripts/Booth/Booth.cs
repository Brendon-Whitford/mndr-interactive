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
    [Tooltip("This transform would be located in the Booth object as a child.")]
    [SerializeField] private Transform boothSittingTransform;
    [SerializeField] private Transform playerTransform;
    [Space]
    [Tooltip("Object used to shoot a raycast out of.")]
    [SerializeField] private Transform rightControllerTransform;

    [Header("Continuous Move Provider")]
    [SerializeField] private ActionBasedContinuousMoveProvider XRMovement;

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
            // RaycastHit hit;
            // creating the point to shoot the ray cast
            Ray rightControllerRay = new(rightControllerTransform.position, rightControllerTransform.forward);

            Debug.Log("Pressed");

            switch(isSitting)
            {
                case true:
                    // shooting the raycast
                    if (Physics.Raycast(rightControllerRay, interactDistance, groundLayerMask))
                    {
                        // enable the movement script
                        XRMovement.enabled = true;
                        isSitting = false;

                        Debug.Log("Leaving booth");
                    }
                break;
                case false:
                    // shooting the raycast
                    if (Physics.Raycast(rightControllerRay, interactDistance, boothLayerMask))
                    {
                        // calling MovePlayer and disabling the movmment script
                        MovePlayer(boothSittingTransform);
                        XRMovement.enabled = false;

                        isSitting = true;

                        Debug.Log("Hit Booth");
                    }
                break;
            }
        }
    }

    private void MovePlayer(Transform transform)
    {
        // setting the player position and rotation to the parameter
        playerTransform.position = transform.position;
        playerTransform.rotation = transform.rotation;
    }
}
