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

    public string orbName;
    public bool activated = false;

    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.onSelectEntered.AddListener(HandleSelectEntered);
        //socketInteractor.onSelectExited.AddListener(HandleSelectExited);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }


    // When the orb is socketed
    private void HandleSelectEntered(XRBaseInteractable interactable)
    {
        // Check the tag of the interactable
        if (interactable.CompareTag(orbName))
        {
            audioSource.volume = 0.8f;

            // Turn off the XR interactor
            interactable.GetComponent<XRBaseInteractor>().enabled = false;

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
            Debug.Log("Incorrect");
        }
    }


    // This is for if we want to do something when the user picks it back up

    /*private void HandleSelectExited(XRBaseInteractable interactable)
    {
        if (interactable.CompareTag("YourTag"))
        {
            interactable.GetComponent<XRBaseInteractor>().enabled = true;
        }
    }*/
}
