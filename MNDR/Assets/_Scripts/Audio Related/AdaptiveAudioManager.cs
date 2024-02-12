using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// This script takes input from AdaptiveAudioSource and AdaptiveAudioTriggerZones.
// It switches to different versions of the mix (called snapshots) when told to do so.
// Edit snapshots in the Audio Mixer window of Unity.

public class AdaptiveAudioManager : MonoBehaviour {

    // array of AudioMixers
    public AudioMixerSnapshot[] snapshotLevels;

    // setting a default and current snapshot
    public int defaultSnapshot;
    private int currentSnapshot;

    void Start() {
        // setting current = default
        currentSnapshot = defaultSnapshot;
    }

	public void SetAudioSnapshot(int level, float transitionTime)
    {
        // setting the currentSnapshot
        currentSnapshot = level;

        // transition to the currentSnapshot at a specific rate of time
        snapshotLevels[currentSnapshot].TransitionTo(transitionTime);
    }

	public void SetDefaultSnapshot(float transitionTime)
    {
        // setting the defaultSnapshot at a specific rate of time
        snapshotLevels[defaultSnapshot].TransitionTo(transitionTime);
    }
}
