using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscLever : MonoBehaviour
{
    public GameObject oscillator;
    public float fineTune;
    float frequency;
    float previousRotation;

    void FixedUpdate()
    {
        previousRotation = this.transform.localEulerAngles.z;
    }

    void LateUpdate() {
        float deltaRotation = this.transform.localEulerAngles.z - previousRotation;
        frequency = deltaRotation * -fineTune;
        frequency = Mathf.Round(frequency * 100.00f) * 0.01f; // cursed way to round to 2 decimal places
        // Debug.Log(frequency);

        if (frequency > -100 && frequency < 100) // Prevent freak jerks 
        oscillator.GetComponent<AudioOscillator>().SetFrequency(frequency);
    }
}
