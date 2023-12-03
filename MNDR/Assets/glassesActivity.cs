using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassesActivity : MonoBehaviour
{
    public GenericInteractionActivity handler;


    void OnTriggerEnter(Collider o) {

        // incrementing the increment function if the activity is complete
        // used to show how many activitys have been complete
        if(o.tag == "FaceCollider") {
            handler.increment();
            Destroy(this.gameObject);
        }
    }
}
