using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script generates a sine wave with a frequency between 40 and 1500. 
// It's used on a test scene which made sine wave generator wheels that the player could turn to make tones and chords.
// Used by the OscLever.cs script.

public class AudioOscillator : MonoBehaviour
{
    [Range(40, 1500)] // Creates a slider in the inspector
    public float frequency;
 
    public float sampleRate = 44100;
    float phase = 0;
   
    void OnAudioFilterRead(float[] data, int channels)
    {
        for(int i = 0 ; i < data.Length ; i += channels)
        {  
            phase += 2 * Mathf.PI * frequency / sampleRate;
 
            data[i] = Mathf.Sin(phase);
 
            if (phase >= 2 * Mathf.PI)
            {
                phase -= 2 * Mathf.PI;
            }
        }
    }

    public void SetFrequency(float freq) {
        frequency += freq;
    }
}