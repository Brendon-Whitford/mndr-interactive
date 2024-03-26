/**
* NPC
* Author: Hayden Dalton
* Description: Attached to the Club NPC as the receiver of the cards. This script has you put
* all the voiceLines you'd like to be heard on the NPC and then plays the line based on the card Number
* relative to the cardNumber amount.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public AudioClip[] voiceLines;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //checks the card number and plays the voiceline relating to that number
    public void CardNumber(int cardNumber)
    {
        Debug.Log("Interacted with card number: " + cardNumber);
        //1/10 chance to say feed me diamonds, to raise the chance replace == with < and then any number above 0
        if (Random.Range(0, 10) == 0)
        {
            Debug.Log("Feed Me Diamonds");
        }
        else if (cardNumber >= 0 && cardNumber < voiceLines.Length) 
        {
            audioSource.PlayOneShot(voiceLines[cardNumber]);
        }
        else
        {
            Debug.Log("Invalid card" + cardNumber);
        }
    }

    //Checks if object has InteractableItem script
    private void OnCollisionEnter(Collision collision)
    {
        InteractableItem interactableItem = collision.gameObject.GetComponent<InteractableItem>();

        if (interactableItem != null)
        {
            interactableItem.Interact(this);
        }
    }
}
