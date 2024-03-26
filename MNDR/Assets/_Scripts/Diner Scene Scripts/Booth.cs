using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
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
    [Header("Currnet XR Rig")]
    [Tooltip("Name for current XR Rig.")]
    [SerializeField] private string XRRigName;

    [Header("Booth Transforms")]
    [SerializeField] private Transform sittingTransform;
    [SerializeField] private Transform exitTransform;

    [Header("Interaction References")]
    [SerializeField] private LayerMask boothLayerMask;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float interactDistance;

    [Space]
    [SerializeField] private GameObject sittingUI;
    [SerializeField] private GameObject exitUI;

    [Tooltip("Boolean to check if the player is sitting.")]
    public bool isSitting;

    private GameObject player;
    private GameObject rightController;
    private ActionBasedContinuousMoveProvider XRMovement;

    private void Awake()
    {
        // grabbing references for player
        rightController = GameObject.Find("RightHand Controller");
        player = GameObject.Find(XRRigName);
        XRMovement = FindFirstObjectByType<ActionBasedContinuousMoveProvider>();
    }

    private void Start()
    {
        isSitting = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("RightController_A"))
        {
            Ray rightControllerRay = new(rightController.transform.position, rightController.transform.forward);

            // shooting the raycast
            if (Physics.Raycast(rightControllerRay, interactDistance, boothLayerMask) && !isSitting)
            {
                // disbale movement
                XRMovement.enabled = false;

                // moving player & setting isSitting to true
                MovePlayer(sittingTransform);
                isSitting = true;
            }
            else if (Physics.Raycast(rightControllerRay, interactDistance, groundLayerMask) && isSitting)
            {
                // enable movement
                XRMovement.enabled = true;

                // moving player & setting isSitting to false
                MovePlayer(exitTransform);
                isSitting = false;
            }
            else
            {
                return;
            }
        }

        exitUI.SetActive(isSitting ? true : false);
    }

    private void FixedUpdate()
    {
        Ray rightControllerRay = new(rightController.transform.position, rightController.transform.forward);

        if (Physics.Raycast(rightControllerRay, interactDistance, boothLayerMask) && !isSitting)
        {
            sittingUI.SetActive(true);
        }
        else if (Physics.Raycast(rightControllerRay, interactDistance, boothLayerMask) && isSitting)
        {
            sittingUI.SetActive(false);
        }
        else
        {
            sittingUI.SetActive(false);
        }
    }

    /// <summary>
    /// Sets the player position and rotation to the parameter.
    /// </summary>
    /// <param name="transform">Transform to set position and rotation.</param>
    private void MovePlayer(Transform transform)
    {
        player.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
