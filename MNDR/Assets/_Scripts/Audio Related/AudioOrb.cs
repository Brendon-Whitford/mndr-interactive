/**
* AudioOrb
* Author: Aria Strasser
* Description: This script goes on an audio orb, which must have an AudioSource. 
*              An audio stem must be dragged into the audioStem variable. The
*              functions on this script need to be attributed to the SelectEntered
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
    public AudioMixerSnapshot audioStem;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PickedUp()
    {
        audioStem.TransitionTo(0.5f);
    }

    public void PutDown()
    {
        audioSource.Stop();
    }
}
