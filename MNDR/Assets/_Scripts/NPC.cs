using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        InteractableItem interactableItem = collision.gameObject.GetComponent<InteractableItem>();

        if (interactableItem != null) {
            interactableItem.Interact(this);

        }
    }

    public void Interaction1(){
        Debug.Log("Interaction1");
    }

    public void Interaction2(){
        Debug.Log("Interaction2");
    }

    public void Interaction3(){
        Debug.Log("Interaction3");
    }
}
