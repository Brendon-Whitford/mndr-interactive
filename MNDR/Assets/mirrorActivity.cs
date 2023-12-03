using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorActivity : MonoBehaviour
{
    public GenericInteractionActivity handler;

    public bool activated = false;
    void OnTriggerEnter(Collider o) {

        // incrementing the increment function if the activity is complete
        // used to show how many activitys have been complete
        if (o.tag == "Player") {
            if(!activated) {
            handler.increment();
            activated = true;
            }
        }
    }
}
