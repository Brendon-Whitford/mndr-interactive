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

public class OrbPedestalNEW : MonoBehaviour
{
    public SocketManager socketManager;

    private XRSocketInteractor socketInteractor;
    public GameObject audioEffectObject;

    private AudioReverbFilter reverbFilter;
    private AudioChorusFilter chorusFilter;
    private AudioDistortionFilter distortionFilter;

    public string orbName;
    public bool activated = false;

    void Awake()
    {
        reverbFilter = audioEffectObject.GetComponent<AudioReverbFilter>();
        chorusFilter = audioEffectObject.GetComponent<AudioChorusFilter>();
        distortionFilter = audioEffectObject.GetComponent<AudioDistortionFilter>();
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
            if (orbName == "RedOrb")
            {
                reverbFilter.enabled = true;
            }
            else if (orbName == "BlueOrb")
            {
                chorusFilter.enabled = true;
            }
            else if (orbName == "BlackOrb")
            {
                distortionFilter.enabled = true;
            }

            // Added feedback??

            activated = true;
            Debug.Log("Correct!!");

            // Check if others are activated
            socketManager.correctSockets++;
            socketManager.CheckSockets();
        }
        else
        {
            Debug.Log("Incorrect");
        }
    }


    // User Picking Up Orb

    private void HandleSelectExited(XRBaseInteractable interactable)
    {
        if (interactable.CompareTag(orbName))
        {
            if (orbName == "RedOrb")
            {
                reverbFilter.enabled = false;
            }
            else if (orbName == "BlueOrb")
            {
                chorusFilter.enabled = false;
            }
            else if (orbName == "BlackOrb")
            {
                distortionFilter.enabled = false;
            }
            activated = false;
            socketManager.correctSockets--;
        }
    }


    // We do it the clunky way because XR had a fit
    /*public void OnTriggerEnter(Collider other)
    {
        AudioSource orbAudioSource = other.GetComponent<AudioSource>();

        if (orbAudioSource != null)
        {
            orbAudioSource.volume = 0f;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        AudioSource orbAudioSource = other.GetComponent<AudioSource>();

        if (orbAudioSource != null)
        {
            orbAudioSource.volume = 0.8f;
        }
    }*/
}
