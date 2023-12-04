using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorActivity : MonoBehaviour
{
    public GenericInteractionActivity handler;

    public bool activated = false;
    void OnTriggerEnter(Collider o) {
        if(o.tag == "Player") {
            if(!activated) {
            handler.increment();
            activated = true;
            }
        }
    }
}
