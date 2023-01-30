using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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