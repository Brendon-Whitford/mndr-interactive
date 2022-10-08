using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AdaptiveAudioManager : MonoBehaviour {

    public int defaultAdaptiveLevel;
    private int currentAdaptiveLevel;
    public AudioMixerSnapshot[] snapshotLevels;
    public float transitionTime = 1;

    void Start() {
        currentAdaptiveLevel = defaultAdaptiveLevel;
    }

	public void AdjustAudioLevel(int level)
    {
        currentAdaptiveLevel = level;
        snapshotLevels[currentAdaptiveLevel].TransitionTo(transitionTime);
        // Debug.Log(level);
    }

	public void SetDefaultAudio()
    {
        snapshotLevels[defaultAdaptiveLevel].TransitionTo(transitionTime);
        // Debug.Log("Reset default");
    }
}
