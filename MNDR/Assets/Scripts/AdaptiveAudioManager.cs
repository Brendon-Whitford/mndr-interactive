using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
