using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    // player references
    private GameObject player;
    private ActionBasedContinuousMoveProvider XRMovement;
    private GameObject rightController;

    [Header("Booth Transforms")]
    [Tooltip("This transform will be located in the Booth object as a child.")]
    [SerializeField] private Transform sittingTransform;
    [SerializeField] private Transform exitTransform;

    [Header("Interaction References")]
    [SerializeField] private LayerMask boothLayerMask;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float interactDistance;
    [Space]
    [SerializeField] private bool isSitting;

    private void Awake()
    {
        rightController = GameObject.Find("RightHand Controller");
        player = GameObject.Find("XR Origin (1)");
        XRMovement = FindFirstObjectByType<ActionBasedContinuousMoveProvider>();
    }

    private void Start()
    {
        isSitting = false; 
    }

    private void Update()
    {
        if(Input.GetButtonDown("RightController_A"))
        {
            // creating the point to shoot the ray cast
            Ray rightControllerRay = new(rightController.transform.position, rightController.transform.forward);

            Debug.Log("Pressed");

            if(isSitting == false)
            {
                // shooting the raycast
                if (Physics.Raycast(rightControllerRay, interactDistance, boothLayerMask))
                {
                    // calling MovePlayer and disabling the movement script
                    MovePlayer(sittingTransform);
                    XRMovement.enabled = false;

                    isSitting = true;

                    Debug.Log("Hit Booth");
                }
            }
            else
            {
                // shooting the raycast
                if (Physics.Raycast(rightControllerRay, interactDistance, groundLayerMask))
                {
                    // enabling movement & setting isSitting to false
                    MovePlayer(exitTransform);
                    XRMovement.enabled = true;

                    isSitting = false;

                    Debug.Log("Hit Ground");
                }
            }
        }
    }

    private void MovePlayer(Transform transform)
    {
        // setting the player position and rotation to the parameter
        player.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
