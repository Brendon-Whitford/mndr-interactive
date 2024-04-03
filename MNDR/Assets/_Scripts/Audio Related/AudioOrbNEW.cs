/**
* AudioOrb
* Author: Aria Strasser
* Description: This script goes on an audio orb, and requires an empty MusicSource object 
*              with the audio effects and an audio source. The functions on this script also 
*              need to be attributed to the SelectEntered and SelectExited Interactable 
*              Events respectively. Orbs must also be tagged.
*              
*              When the user picks up the orb, it will turn on an audio effect, and when the 
*              user lets go, it will turn that effect off.
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
        if (this.tag == "RedOrb")
        {
            reverbFilter.enabled = false;
        }
        else if (this.tag == "BlueOrb")
        {
            chorusFilter.enabled = false;
        }
        else if (this.tag == "BlackOrb")
        {
            distortionFilter.enabled = false;
        }
    }
}
