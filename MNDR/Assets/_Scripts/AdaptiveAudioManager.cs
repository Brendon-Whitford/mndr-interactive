using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// This script takes input from AdaptiveAudioSource and AdaptiveAudioTriggerZones.
// It switches to different versions of the mix (called snapshots) when told to do so.
// Edit snapshots in the Audio Mixer window of Unity.

public class AdaptiveAudioManager : MonoBehaviour {

    public AudioMixerSnapshot[] snapshotLevels;

    public int defaultSnapshot;
    private int currentSnapshot;

    void Start() {
        currentSnapshot = defaultSnapshot;
    }

	public void SetAudioSnapshot(int level, float transitionTime)
    {
        currentSnapshot = level;
        snapshotLevels[currentSnapshot].TransitionTo(transitionTime);
    }

	public void SetDefaultSnapshot(float transitionTime)
    {
        snapshotLevels[defaultSnapshot].TransitionTo(transitionTime);
    }
}
