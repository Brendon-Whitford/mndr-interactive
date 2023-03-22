/**
 * GenericInteractionActivity.cs
 * Author: Jackson Looney
 * Description: Base Handler for adding activities to the game. Will check if things are interacted with a number of times.
 * Meant to be utilized alongside another script that has a reference to this one, if any of the objects that are in the list don't have a reference to this script/object, or don't call increment(), it will throw errors, or will never complete.
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GenericInteractionActivity : MonoBehaviour
{

    [Header("Necessary components to set")]
    //List of interactables that must be interacted with
    public List<GameObject> objects = new List<GameObject>();
    
    //Reward for completing activity
    public GameObject card;

    //Transform of the player, for spawning the reward
    private Transform playerPos;

    [Header("Offset for spawning the reward in relation to the player")]
    [SerializeField]
    private int offset = 2;
    
    //count for completed interactions
    private int completedInteractions = 0;

    void Update()
    {
        playerPos = FindObjectOfType<CharacterController>().transform;
        
        if(completedInteractions >= objects.Count) {
            OnComplete();
        }
    }

    // The method to increment amound of interactions 
    public void increment() {
        completedInteractions++;
    }

    //This is called when all objects in the list have been activated
    void OnComplete() {
        // If the reward has been set in the inspector
        if(card != null) {
            Instantiate(card, new Vector3(playerPos.position.x + offset, playerPos.position.y + offset, playerPos.position.z + offset), transform.rotation);
        } else {
            Debug.Log("Activity" + this.name + "Complete");
        }

        this.enabled = false;
    }
    
}
