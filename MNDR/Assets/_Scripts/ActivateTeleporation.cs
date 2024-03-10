/**
* ActivateTeleporation
* Author: Hayden Dalton
* Description: The purpose of this script only activate the teleporation ray when the player
*              is holding down the trigger and teleports them when they release it.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleporation : MonoBehaviour
{
    public GameObject leftTeleportation;
    //public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    //public InputActionProperty rightActivate;

    public bool canTeleport = false;

    void Update()
    {
        if (canTeleport)
        {
            Vector2 leftThumbstickValue = leftActivate.action.ReadValue<Vector2>();
            leftTeleportation.SetActive(leftThumbstickValue.magnitude > 0.1f);            //rightTeleportation.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
        }
        else
        {
            leftTeleportation.SetActive(false);
            //rightTeleportation.SetActive(false);
        }
    }
}
