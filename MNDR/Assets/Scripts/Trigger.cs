using System;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
 
    public AudioClip nextMusic;
    public AudioSource audioObject;
 
    void Start()
    {
        audioObject = gameObject.GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { // only an object tagged Player stops the sound
            audioObject.Stop();
            Debug.Log("Player entered!");
        }
    }
 
    void OnTriggerExit(Collider other)
        //use ontriggerexit 2D instead of no 2D because of collider
   
    {
        if (other.tag == "Player")
        { // only an object tagged Player restarts the sound
            audioObject.clip = nextMusic;  // select the next music
            audioObject.Play(); // play it
            Debug.Log("Player exit!");
        }
    }
}
