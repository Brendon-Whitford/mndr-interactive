/**
* AudioSliderController
* Author: Hayden Dalton
* Description: Very simple script that sets the volume of the audio mixers master
*              Volume relative to the slider, this doesn't need to be saved in Memory since the audio
*              mixers save between scenes and would reset when restarted.
*              You just set this script up in the menu somewhere and grab the audio mixers we want
*              Then "On Value Changed" in the slider have it call the function "SetVolume".
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSliderController : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioMixer;
    
    public void SetVolume (float sliderValue) {
        //Changes slider value to logarithic value which is what volumeMixers use
        //Min Value of Slider set to 0.0001 because of this
        myAudioMixer.SetFloat("Test", Mathf.Log10(sliderValue) * 20);
    }
}
