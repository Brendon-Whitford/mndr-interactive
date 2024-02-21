using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Settings : MonoBehaviour
{
    [Header ("Audio")]
    [SerializeField] private AudioMixer myAudioMixer;

    [Header ("Turning Buttons")]
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider continuousTurn;
    public Toggle toggleSnap;
    public Toggle toggleCon;

    [Header ("Movement Buttons")]
    public ActionBasedContinuousMoveProvider continuousMove;
    public TeleportationProvider teleportation;
    public Toggle toggleConMove;
    public Toggle toggleTeleport;

    public void SetVolume (float sliderValue) {
        //Changes slider value to logarithic value which is what volumeMixers use
        //Min Value of Slider set to 0.0001 because of this
        myAudioMixer.SetFloat("Test", Mathf.Log10(sliderValue) * 20);
    }

    //Put this on the snap turn button
    public void SwapToSnap(bool isOn){
        if (isOn)
        {
            toggleCon.isOn = false;
            toggleCon.interactable = true;
            toggleSnap.interactable = false;
            
            snapTurn.enabled = true;
            continuousTurn.enabled = false;
        }
    }

    //Put this on the continuous turn button
    public void SwapToConTurn(bool isOn){
        if (isOn)
        {
            toggleSnap.isOn = false;
            toggleCon.interactable = false;
            toggleSnap.interactable = true;
          
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        }
    }

    //Put this on the continuous move button
    public void SwapToConMove(bool isOn){
        if (isOn)
        {
            toggleTeleport.isOn = false;
            toggleTeleport.interactable = true;
            toggleConMove.interactable = false;

            teleportation.enabled = false;
            continuousMove.enabled = true;
        }
    }

    //Put this on the Teleportation button
    public void SwapToTeleport(bool isOn){
        if (isOn)
        {
            toggleConMove.isOn = false;
            toggleTeleport.interactable = false;
            toggleConMove.interactable = true;

            teleportation.enabled = true;
            continuousMove.enabled = false;
        }
    }

    
    
}
