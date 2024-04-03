/**
* UIHapticsSound
* Author: Aria Strasser
* Description: This script goes on the buttons on any menu. The menu must have an
*              AudioSource. When the button is hovered, a sound will play and the
*              user will experience some haptic feedback. When a button is selected,
*              a different sound is played and the user experiences stronger haptic
*              feedback. Takes two audio clips and an audio source.
*/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class UIHapticsSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip hoverSound;
    public AudioClip selectSound;
    public AudioSource audioSource;

    // Button is entered
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSound);
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).SendHapticImpulse(0, 0.3f, 0.1f);
    }

    // Button is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(selectSound);
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).SendHapticImpulse(0, 1f, 0.3f);
    }
}
