using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private bool interact1 = false;
    [SerializeField] private bool interact2 = false;
    [SerializeField] private bool interact3 = false;

    public void Interact(NPC npc) {

        if(interact1){
            npc.Interaction1();
        }
        else if(interact2){
            npc.Interaction2();
        }
        else if(interact3) {
            npc.Interaction3();
        }
        else {
            Debug.Log("Please Select an Interaction");
        }
        Destroy(gameObject);
    }

    
}
