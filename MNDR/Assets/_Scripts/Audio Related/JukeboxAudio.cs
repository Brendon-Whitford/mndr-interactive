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
            //Stop any other AudioClips

            // Get the AudioClip from the record object
            AudioClip recordClip = other.gameObject.GetComponent<AudioSource>().clip;

            // Play the audio clip from the record
            audioSource.clip = recordClip;
            audioSource.Play();

            // Put Record BACK
        }
    }
}
