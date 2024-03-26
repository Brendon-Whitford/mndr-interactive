/**
* InteractableItem
* Author: Hayden Dalton
* Description:  Very simple script, just put it on each of the cards and assign it a number.
* this script it meant to work together with the "NPC" script to hand the NPC a card with a given
* number and get a response based on that number.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private int cardNumber = 0;

    public void Interact(NPC npc) {

        npc.CardNumber(cardNumber);
        Destroy(gameObject);
    }

    
}
