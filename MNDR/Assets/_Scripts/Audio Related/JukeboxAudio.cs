/**
* JukeboxAudio
* Author: Aria Strasser
* Description: This script goes on a Jukebox, which must have an AudioSource. 
*              When an object tagged as a Record is touched to it, it will play
*              the audio that is attached to the Record (Record must have an
*              AudioSource with an AudioClip attached).
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume = 0.5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Record"))
        {
            //Stop any other AudioClips here if needed

            // Get the AudioClip from the record object
            AudioClip recordClip = other.gameObject.GetComponent<AudioSource>().clip;

            // Play the audio clip from the record
            audioSource.clip = recordClip;
            audioSource.Play();
        }
    }
}
