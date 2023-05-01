using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hourglassActivity : MonoBehaviour
{
    public GenericInteractionActivity handler;

    public bool complete = false;
    void OnTriggerEnter(Collider o) {
        if(o.tag == "Pedestal") {
            if(!complete) {
            handler.increment();
            complete = true;
            }
        }
    }
}
