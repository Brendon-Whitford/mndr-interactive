using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be placed on box trigger object.
// When the player enters it, it stops some audio sources and plays others.
// You can make it wait for the old audio sources to finish before playing the next ones.

public class PlayAudioTrigger : MonoBehaviour {

    public List<GameObject> audioToPlay;
    public List<GameObject> audioToStop;

    public bool syncWithAudio = true;
    public GameObject audioToSync;

    bool playNext = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player") {
            if (!syncWithAudio || audioToSync == null) {
                SwitchAudio();
            } else {
                playNext = true;
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
        for (int i=0; i < audioToPlay.Count; i++) {
            audioToPlay[i].GetComponent<AudioSource>().Play();
        }
        for (int w=0; w < audioToStop.Count; w++) {
            audioToStop[w].GetComponent<AudioSource>().Stop();
        }
    }
}
