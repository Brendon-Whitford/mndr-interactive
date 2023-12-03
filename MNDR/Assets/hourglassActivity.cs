using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hourglassActivity : MonoBehaviour
{
    public GenericInteractionActivity handler;

    public bool complete = false;
    void OnTriggerEnter(Collider o) {

        // incrementing the increment function if the activity is complete
        // used to show how many activitys have been complete
        if (o.tag == "Pedestal") {
            if(!complete) {
            handler.increment();
            complete = true;
            }
        }
    }
}
