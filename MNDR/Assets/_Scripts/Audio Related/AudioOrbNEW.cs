/**
* AudioOrb
* Author: Aria Strasser
* Description: This script goes on an audio orb, which must have an AudioSource.
*              The AudioSource should have a group (the stem you want to play) and a
*              clip of the audio you want played. Play on Awake and Loop must be checked.
*              The functions on this script also need to be attributed to the SelectEntered
*              and SelectExited Interactable Events respectively. Orbs must also be tagged.
*              
*              When the user picks up the orb, it will play an audio stem, and when the 
*              user lets go, it will stop playing.
*              
*              Works in conjunction with OrbPedestal and SocketManager scripts
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

    void Awake()
    {
        /*audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;*/
        reverbFilter = audioEffectObject.GetComponent<AudioReverbFilter>();
        chorusFilter = audioEffectObject.GetComponent<AudioChorusFilter>();
        distortionFilter = audioEffectObject.GetComponent<AudioDistortionFilter>();
    }

    // Start Effect on Pick Up
    public void PickedUp()
    {
        if (this.tag == "RedOrb")
        {
            reverbFilter.enabled = true;
        }
        else if (this.tag == "BlueOrb")
        {
            chorusFilter.enabled = true;
        }
        else if (this.tag == "BlackOrb")
        {
            distortionFilter.enabled = true;
        }
    }

    // Stop Effect on Put Down
    public void PutDown()
    {
        reverbFilter.enabled = false;
        chorusFilter.enabled = false;
        distortionFilter.enabled = false;
    }
}
