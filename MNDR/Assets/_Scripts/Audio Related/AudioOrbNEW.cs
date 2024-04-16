/**
* AudioOrb
* Author: Aria Strasser
* Description: This script goes on an audio orb, and requires an empty MusicSource object 
*              with the audio effects and an audio source. The functions on this script also 
*              need to be attributed to the SelectEntered and SelectExited Interactable 
*              Events respectively. Orbs must also be tagged.
*              
*              When the user picks up the orb, it will turn on an audio effect, and when the 
*              user lets go, it will turn that effect off. Picking up a second orb will silence
*              the original effect and play the new one.
*              
*              Works in conjunction with OrbPedestalNEW and SocketManager scripts
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOrbNEW : MonoBehaviour
{
    //private AudioSource audioSource;
    public GameObject audioEffectObject;
    private AudioReverbFilter reverbFilter;
    private AudioChorusFilter chorusFilter;
    private AudioDistortionFilter distortionFilter;
    private AudioHighPassFilter highPassFilter;
    private AudioLowPassFilter lowPassFilter;
    private AudioEchoFilter echoFilter;
    public GameObject pedestal;
    public OrbPedestalNEW pedestalScript;

    void Awake()
    {
        reverbFilter = audioEffectObject.GetComponent<AudioReverbFilter>();
        chorusFilter = audioEffectObject.GetComponent<AudioChorusFilter>();
        distortionFilter = audioEffectObject.GetComponent<AudioDistortionFilter>();
        highPassFilter = audioEffectObject.GetComponent<AudioHighPassFilter>();
        lowPassFilter = audioEffectObject.GetComponent<AudioLowPassFilter>();
        echoFilter = audioEffectObject.GetComponent<AudioEchoFilter>();
        pedestalScript = pedestal.GetComponent<OrbPedestalNEW>();
    }

    // Start Effect on Pick Up
    public void PickedUp()
    {
        if (!pedestalScript.activated)
        {
            if (this.tag == "ReverbOrb")
            {
                reverbFilter.enabled = true;
                chorusFilter.enabled = false;
                distortionFilter.enabled = false;
                highPassFilter.enabled = false;
                lowPassFilter.enabled = false;
                echoFilter.enabled = false;
            }
            else if (this.tag == "ChorusOrb")
            {
                chorusFilter.enabled = true;
                distortionFilter.enabled = false;
                reverbFilter.enabled = false;
                lowPassFilter.enabled = false;
                echoFilter.enabled = false;
                highPassFilter.enabled = false;
            }
            else if (this.tag == "DistortionOrb")
            {
                distortionFilter.enabled = true;
                chorusFilter.enabled = false;
                reverbFilter.enabled = false;
                lowPassFilter.enabled = false;
                echoFilter.enabled = false;
                highPassFilter.enabled = false;
            }
            else if (this.tag == "LowPassOrb")
            {
                distortionFilter.enabled = false;
                chorusFilter.enabled = false;
                reverbFilter.enabled = false;
                lowPassFilter.enabled = true;
                echoFilter.enabled = false;
                highPassFilter.enabled = false;
            }
            else if (this.tag == "EchoOrb")
            {
                distortionFilter.enabled = false;
                chorusFilter.enabled = false;
                reverbFilter.enabled = false;
                lowPassFilter.enabled = false;
                echoFilter.enabled = true;
                highPassFilter.enabled = false;
            }
            else if (this.tag == "HighPassOrb")
            {
                distortionFilter.enabled = false;
                chorusFilter.enabled = false;
                reverbFilter.enabled = false;
                lowPassFilter.enabled = false;
                echoFilter.enabled = false;
                highPassFilter.enabled = true;
            }
        }
    }

    // Stop Effect on Put Down
    public void PutDown()
    {
        if (this.tag == "ReverbOrb")
        {
            reverbFilter.enabled = false;
        }
        else if (this.tag == "ChorusOrb")
        {
            chorusFilter.enabled = false;
        }
        else if (this.tag == "DistortionOrb")
        {
            distortionFilter.enabled = false;
        }
        else if (this.tag == "LowPassOrb")
        {
            lowPassFilter.enabled = false;
        }
        else if (this.tag == "EchoOrb")
        {
            echoFilter.enabled = false;
        }
        else if (this.tag == "HighPassOrb")
        {
            highPassFilter.enabled = false;
        }
    }
}
