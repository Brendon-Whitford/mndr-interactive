using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be placed on box trigger object.
// When the player enters it, it tells the audio manager to switch snapshots.

// require a box collider for this script to work
[RequireComponent(typeof(BoxCollider))]
public class AdaptiveAudioTriggerZone : MonoBehaviour {

    public GameObject audioManager;

    [Header("Snapshot to switch to upon player entering the trigger. (starts with 0)")]
    public int snapshot;
    [Header("Transition time to new snapshot in seconds.")]
    public float transitionTime;

    // Swap to an audio snapshot upon entering the trigger.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player") {
            // grabing the AdaptiveAudioManager and calling the SetAdutioSnapshot method
            audioManager.GetComponent<AdaptiveAudioManager>().SetAudioSnapshot(snapshot, transitionTime);
            // Debug.Log("Switch audio");
        }
    }

    // Swap to the default snapshot upon player exiting the trigger.
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player") {
            // grabing the AdaptiveAudioManager and calling the SetDefaultSnapshot method
            audioManager.GetComponent<AdaptiveAudioManager>().SetDefaultSnapshot(transitionTime);
        }
    } 


    // Draw unity editor trigger boxes a certain color, for organization
    void OnDrawGizmosSelected()
    {
        Gizmos.color = GetGizmoColor();
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, GetComponent<BoxCollider>().size);        
    }  

    // setting the color of the gizmos depending on the snapshot
    private Color GetGizmoColor()
    {
        switch (snapshot)
        {
            case 0:
            case 2:
                return Color.black;  //default is black

            case 1:
                return Color.green;

            case 3:
                return Color.yellow;

            case 4:
                return new Color(.4f, .1f, .6f); //purple

            case 5:
                return Color.red;
        }
        return Color.black;
    } 
}
