using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorActivity : MonoBehaviour
{
    public GenericInteractionActivity handler;


    void OnTriggerEnter(Collider o) {
        if(o.tag == "Player") {
            handler.increment();
        }
    }
}
