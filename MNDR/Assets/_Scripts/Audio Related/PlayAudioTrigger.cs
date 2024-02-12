﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be placed on an object with a box collider set to Is Trigger.
// When the player enters it, it stops some audio sources and plays others.
// You can make it wait for the old audio sources to finish before playing the next ones.
// elias@willerup.com

public class PlayAudioTrigger : MonoBehaviour {
    [Header("Audio to Play")]
    public List<GameObject> audioToPlay;

    [Header("Audio to Stop")]
    public List<GameObject> audioToStop;

    [Header("Triggers to Disable")]
    public List<GameObject> audioTriggersToDisable;

    public bool syncWithAudio = true;
    public GameObject audioToSync;

    bool playNext = false;

    void OnTriggerEnter(Collider collider)
    {
        // changing the audio
        if (collider.tag == "Player") {
            if (!syncWithAudio || audioToSync == null) {
                SwitchAudio();
            } else {
                playNext = true;
                Debug.Log("playing next audio..");
            }

        }
    }

    void Update() {
        if (playNext) {
            if (audioToSync.GetComponent<AudioSource>().time < 0.1) {
                SwitchAudio();
                playNext = false;
            }
        }

        // Debug.Log(audioToSync.GetComponent<AudioSource>().time);
    }

    void SwitchAudio() {
        // audio to play
        for (int i=0; i < audioToPlay.Count; i++) {
            audioToPlay[i].GetComponent<AudioSource>().Play();
        }

        // audio to stop
        for (int w=0; w < audioToStop.Count; w++) {
            audioToStop[w].GetComponent<AudioSource>().Stop();
        }

        // setting audio triggers to false
        for (int k=0; k < audioTriggersToDisable.Count; k++) {
            audioTriggersToDisable[k].gameObject.SetActive(false);
        }
    }
}
