using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * Created By Carson McMahan || 01/26/2024
 * This script was built for sitting the player at a booth inside of the hub world.
 * If the player points the right controller at the booth and presses A, they will "sit" at the booth.
 * If the player points the right controller at the groud and presses A, then they can walk around.
 */

public class Booth : MonoBehaviour
{
    [Tooltip("Name for current XR Rig.")]
    [SerializeField] private string XRRigName;

    [Header("Booth Transforms")]
    [SerializeField] private Transform sittingTransform;
    [SerializeField] private Transform exitTransform;

    [Header("Interaction References")]
    [SerializeField] private LayerMask boothLayerMask;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float interactDistance;
    [SerializeField] private GameObject sittingUI;
    [SerializeField] private GameObject exitUI;

    [Space]
    [Tooltip("Boolean to check if the player is sitting.")]
    public bool isSitting;

    private Transform player;
    private Transform rightController;

    private ActionBasedContinuousMoveProvider conMovement;
    private TeleportationProvider telportMovement;
    bool isContinuouse;
    bool isTeleport;

    private void Awake()
    {
        rightController = GameObject.Find("RightHand Controller").transform;
        player = GameObject.Find(XRRigName).transform;

        conMovement = player.GetComponent<ActionBasedContinuousMoveProvider>();
        telportMovement = player.GetComponent<TeleportationProvider>();
    }

    private void Start()
    {
        CheckMovementType();

        isSitting = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("RightController_A"))
        {
            // creating a raycast out of the right controller
            Ray rightControllerRay = new(rightController.position, rightController.forward);

            if (Physics.Raycast(rightControllerRay, interactDistance, boothLayerMask) && !isSitting)
            {
                SitAction();
            }
            else if (Physics.Raycast(rightControllerRay, interactDistance, groundLayerMask) && isSitting)
            {
                ExitAction();
            }
        }

        exitUI.SetActive(isSitting);
    }

    private void FixedUpdate()
    {
        // creating a raycast out of the right controller
        Ray rightControllerRay = new(rightController.position, rightController.forward);

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
    /// hanldes action when the player sits in the booth.
    /// </summary>
    /// <returns>Returns isSitting = true.</returns>
    private bool SitAction()
    {
        if (isContinuouse)
            conMovement.enabled = false;
        else if (isTeleport)
            telportMovement.enabled = false;

        MovePlayer(sittingTransform);
        return isSitting = true;
    }

    /// <summary>
    /// Handles actions when the player exits the booth.
    /// </summary>
    /// <returns>Returns isSitting = false.</returns>
    private bool ExitAction()
    {
        if (isContinuouse)
            conMovement.enabled = true;
        else if (isTeleport)
            telportMovement.enabled = true;

        MovePlayer(exitTransform);
        return isSitting = false;
    }

    /// <summary>
    /// Sets the player position and rotation to the parameter.
    /// </summary>
    /// <param name="transform">Transform to set position and rotation.</param>
    private void MovePlayer(Transform transform)
    {
        player.SetPositionAndRotation(transform.position, transform.rotation);
    }

    /// <summary>
    /// Checks to see which movement type is enabled.
    /// </summary>
    private void CheckMovementType()
    {
        isContinuouse = conMovement.enabled;
        isTeleport = telportMovement.enabled;
    }
}
