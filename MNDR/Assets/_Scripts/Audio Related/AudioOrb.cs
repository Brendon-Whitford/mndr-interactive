/**
* AudioOrb
* Author: Aria Strasser
* Description: This script goes on an audio orb, which must have an AudioSource. 
*              The functions on this script need to be attributed to the SelectEntered
*              and SelectExited Interactable Events respectively. When the user picks
*              up the orb, it will play an audio stem, and when the user lets go, it
*              will stop playing.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioOrb : MonoBehaviour
{
    //public AudioMixerSnapshot audioStem;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }

    // Start Music on Pick Up
    public void PickedUp()
    {
        audioSource.volume = 0.8;
    }

    // Stop Music on Put Down
    public void PutDown()
    {
        audioSource.volume = 0;
    }
}
