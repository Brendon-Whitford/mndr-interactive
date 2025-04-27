using System.Data.Common;
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
    [SerializeField] private float interactDistance;
    [SerializeField] private GameObject sittingUI;
    [SerializeField] private GameObject exitUI;
    [SerializeField] private MeshCollider boothCollider;
    [Space]
    [Tooltip("Boolean to check if the player is sitting.")]
    public bool isSitting;

    private LayerMask boothLayerMask;
    private LayerMask groundLayerMask;

    private Transform player;
    private Transform rightController;

    private ActionBasedContinuousMoveProvider conMovement;
    private TeleportationProvider telportMovement;
    bool isContinuouse;
    bool isTeleport;

    private void Awake()
    {
        // finding the right controller and the player
        rightController = GameObject.Find("RightHand Controller").transform;
        player = GameObject.Find(XRRigName).transform;

        // grabbin the components for Continuous and Teleportation movement
        conMovement = player.gameObject.GetComponent<ActionBasedContinuousMoveProvider>();
        telportMovement = player.gameObject.GetComponent<TeleportationProvider>();
    }

    private void Start()
    {
        // setting layer masks
        boothLayerMask = LayerMask.GetMask("BoothLayer");
        groundLayerMask = LayerMask.GetMask("GroundLayer");

        boothCollider.enabled = true;

        isSitting = false;

        CheckMovementType();
    }

    private void Update()
    {
        if (Input.GetButtonDown("RightController_A"))
        {
            if (Physics.Raycast(RightControllerRaycast(), interactDistance, boothLayerMask) && !isSitting)
            {
                SitAction();
            }
            else if (Physics.Raycast(RightControllerRaycast(), interactDistance, groundLayerMask) && isSitting)
            {
                ExitAction();
            }
        }

        exitUI.SetActive(isSitting);
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(RightControllerRaycast(), out RaycastHit hit, interactDistance))
        {
            if (((1 << hit.collider.gameObject.layer) & boothLayerMask) != 0 && !isSitting)
            {
                sittingUI.SetActive(true);
            }
            else
            {
                sittingUI.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Creates raycast out of the Right Controller transform.
    /// </summary>
    /// <returns>Returns the ray.</returns>
    private Ray RightControllerRaycast()
    {
        return new Ray(rightController.position, rightController.forward);
    }
    
    /// <summary>
    /// hanldes action when the player sits in the booth.
    /// </summary>
    /// <returns>Returns isSitting = true.</returns>
    private void SitAction()
    {
        if (isContinuouse)
            conMovement.enabled = false;
        else if (isTeleport)
            telportMovement.enabled = false;

        boothCollider.enabled = false;
        MovePlayer(sittingTransform);
        isSitting = true;
    }

    /// <summary>
    /// Handles actions when the player exits the booth.
    /// </summary>
    /// <returns>Returns isSitting = false.</returns>
    private void ExitAction()
    {
        if (isContinuouse)
            conMovement.enabled = true;
        else if (isTeleport)
            telportMovement.enabled = true;

        boothCollider.enabled = true;
        MovePlayer(exitTransform);
        isSitting = false;
    }

    /// <summary>
    /// Returns Movement to player. Reference this on the scene transition when grabbing food item.
    /// </summary>
    public void ReturnMovement()
    {
        if (isContinuouse)
            conMovement.enabled = true;
        else if (isTeleport)
            telportMovement.enabled = true;
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

        Debug.Log($"{isContinuouse}, {isTeleport}");
    }
}
