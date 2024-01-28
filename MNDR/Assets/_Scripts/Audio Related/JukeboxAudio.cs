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
    //public AudioClip clip;
    public float volume = 0.5f;

    // Leaving start here in case we want it to be naturally playing music on scene start
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Record"))
        {
            //GoHome goHome = other.transform.parent.GetComponent<GoHome>();

            //Stop any other AudioClips

            // Get the AudioClip from the record object
            AudioClip recordClip = other.gameObject.GetComponent<AudioSource>().clip;

            // Play the audio clip from the record
            audioSource.clip = recordClip;
            audioSource.Play();

            // Put Record BACK
            //goHome.returnHome();
        }
    }
}
