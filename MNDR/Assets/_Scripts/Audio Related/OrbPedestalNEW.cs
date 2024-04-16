/**
* OrbPedestalNEW
* Author: Aria Strasser
* Description: This script goes on a socket for an AudioOrb. Requires a String for the correct tag
*              and an empty MusicSource object with the audio effects and an audio source.
*              
*              When the user places an orb on the pedestal, it will check the tag (Make sure
*              to tag the orbs) and turn on the relative effect on the MusicSource, and change 
*              activated to true. While an orb is on the pedestal, held orbs will not change the
*              audio.
*                            
*              Works in conjunction with AudioOrbNEW script.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OrbPedestalNEW : MonoBehaviour
{
    //public SocketManager socketManager;

    private XRSocketInteractor socketInteractor;
    public GameObject audioEffectObject;

    private AudioReverbFilter reverbFilter;
    private AudioChorusFilter chorusFilter;
    private AudioDistortionFilter distortionFilter;
    private AudioHighPassFilter highPassFilter;
    private AudioLowPassFilter lowPassFilter;
    private AudioEchoFilter echoFilter;

    public string orbName;
    public bool activated = false;


    void Awake()
    {
        reverbFilter = audioEffectObject.GetComponent<AudioReverbFilter>();
        chorusFilter = audioEffectObject.GetComponent<AudioChorusFilter>();
        distortionFilter = audioEffectObject.GetComponent<AudioDistortionFilter>();
        highPassFilter = audioEffectObject.GetComponent<AudioHighPassFilter>();
        lowPassFilter = audioEffectObject.GetComponent<AudioLowPassFilter>();
        echoFilter = audioEffectObject.GetComponent<AudioEchoFilter>();
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
        // Check the tag of the interactable and start that effect
        
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
        else if (orbName == "GreyOrb")
        {
            lowPassFilter.enabled = true;
        }
        else if (orbName == "BrownOrb")
        {
            echoFilter.enabled = true;
        }
        else if (orbName == "PurpleOrb")
        {
            highPassFilter.enabled = true;
        }
        
        activated = true;        
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
            else if (orbName == "GreyOrb")
            {
                lowPassFilter.enabled = false;
            }
            else if (orbName == "BrownOrb")
            {
                echoFilter.enabled = false;
            }
            else if (orbName == "PurpleOrb")
            {
                highPassFilter.enabled = false;
            }
            activated = false;
        }
    }
}
