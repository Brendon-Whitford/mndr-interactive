using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AdaptiveAudioTrigger : MonoBehaviour {

    public int triggerLevel;
    public GameObject AdaptiveAudioManager;
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = GetGizmoColor();
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, GetComponent<BoxCollider>().size);        
    }

    private Color GetGizmoColor()
    {
        switch (triggerLevel)
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player") {
            AdaptiveAudioManager.SendMessage("AdjustAudioLevel", triggerLevel);
            // Debug.Log("Switch audio");
        }
    }



    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player") {
            AdaptiveAudioManager.SendMessage("SetDefaultAudio");
        }
    }    
}
