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


public class AudioOrb : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }

    // Start Music on Pick Up
    public void PickedUp()
    {
        audioSource.volume = 0.8f;
    }

    // Stop Music on Put Down
    public void PutDown()
    {
        audioSource.volume = 0;
    }
}
