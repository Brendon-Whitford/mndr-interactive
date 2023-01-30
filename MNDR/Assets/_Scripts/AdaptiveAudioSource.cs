using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be placed on an audio source.
// When the audio source reaches a specified time, it tells the audio manager to switch snapshots.

public class AdaptiveAudioSource : MonoBehaviour
{
    public GameObject audioManager;

    [Header("When the audio change should take place. (in seconds)")]
    public float timeToChange;
    [Header("Snapshot to switch to upon reaching said time. (starts with 0)")]
    public int snapshot;
    [Header("Transition time to new snapshot in seconds.")]
    public float transitionTime;
    [Header("Useful for telling when to make the change.")]
    public bool debugPlaybackTime = false;

    bool switchedAlready = false;

    void Start() {
        // Set timeToChange to -1 to disable.
        if (timeToChange == -1) {
            switchedAlready = true;
        }
    }

    void Update()
    {
        // "Playback has reached 123 seconds in. Switch to the new snapshot"
        if (this.GetComponent<AudioSource>().time > timeToChange && !switchedAlready)
        {
            audioManager.GetComponent<AdaptiveAudioManager>().SetAudioSnapshot(snapshot, transitionTime);
            switchedAlready = true;
        }
        
        if (debugPlaybackTime) {
            Debug.Log(this.GetComponent<AudioSource>().time);
        }
    }
}
