using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * Created By Carson McMahan || 02/09/2024
 * This script is being used to set the transform of an interactable
 * object to the hand that the player uses to pick up the object.
 */

[RequireComponent(typeof(XRGrabInteractable))]
public class ParentToObject : MonoBehaviour
{
    [Tooltip("This transform is the root object that houses everything for an interactable object.")]
    [SerializeField] private Transform interactable;

    // parenting the object
    public void ParentToHand(SelectEnterEventArgs hand)
    {
        interactable.SetParent(hand.interactorObject.transform);
    }

    // setting it to null to unparent
    public void UnparentToHand()
    {
        interactable.SetParent(null);
    }
}
