using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Put this script on an audio source.
// When 'PlayAudio()' is called, the audio will play after the 'oldAudio' object has finished playing.
// For example, the player just walked into a new area- start the next part of the song after the current one is finished.
// Allows for cleaner transitions while giving the player some control.

public class PlayAudioOnFinished : MonoBehaviour
{
    [Header("When 'PlayAudio()' is called, play when 'oldAudio' has reached the end of its playback.")]
    public GameObject[] oldAudio;
    public bool stopOldAudio = false;
    bool playNextAudio = false;

    AudioSource oldAudioSource;
    AudioSource newAudioSource;

    void Start() {
        oldAudioSource = oldAudio[0].GetComponent<AudioSource>();
        newAudioSource = this.GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        playNextAudio = true;
    }

    void Update() {
        if (playNextAudio && oldAudioSource.isPlaying == false) {
            newAudioSource.Play();
            if (stopOldAudio) {
                oldAudioSource.Stop();
            }
        }
    }
}
