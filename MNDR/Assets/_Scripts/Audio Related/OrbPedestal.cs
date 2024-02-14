/**
* OrbPedestal
* Author: Aria Strasser
* Description: This script goes on a socket for an AudioOrb, which must have an AudioSource.
*              The AudioSource should have a group (the stem you want to play) and a
*              clip of the audio you want played. Play on Awake and Loop must be checked.
*              Takes a String for the correct tag, an empty SocketManager object.
*              
*              When the user places an orb on the pedestal, it will check the tag (Make sure
*              to tag the orbs). If it is the correct orb, it will start playing the audio,
*              turn off the XR Interactable, change activated to true, and then ask the 
*              SocketManager if all orbs are correctly placed.
*              
*              If all are correctly placed it will turn off the AudioSource.
*              
*              Works in conjunction with AudioOrb and SocketManager scripts
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OrbPedestal : MonoBehaviour
{
    public SocketManager socketManager;

    private XRSocketInteractor socketInteractor;
    private AudioSource audioSource;
    private AudioSource orbAudioSource;

    public string orbName;
    public bool activated = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }

    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.onSelectEntered.AddListener(HandleSelectEntered);
        socketInteractor.onSelectExited.AddListener(HandleSelectExited);

        
    }


    // When the orb is socketed
    private void HandleSelectEntered(XRBaseInteractable interactable)
    {
        // Check the tag of the interactable
        if (interactable.CompareTag(orbName))
        {
            audioSource.volume = 0.8f;

            orbAudioSource = interactable.GetComponent<AudioSource>();

            // Turn off the XR interactor (was causing an error and may not be needed)
            //interactable.GetComponent<XRBaseInteractor>().enabled = false;

            orbAudioSource.volume = 0;

            // Added feedback??

            activated = true;
            Debug.Log("Correct!!");

            // Check if others are activated
            socketManager.correctSockets++;
            socketManager.CheckSockets();

            // If sockets are all correct, silence the audio listener

        }
        else
        {
            audioSource.volume = 0;
            Debug.Log("Incorrect");
        }
    }


    // User Picking Up Orb

    private void HandleSelectExited(XRBaseInteractable interactable)
    {
        audioSource.volume = 0;

        if (interactable.CompareTag(orbName))
        {
            activated = false;
            socketManager.correctSockets--;
        }
    }
}
