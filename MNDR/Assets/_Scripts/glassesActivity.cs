using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassesActivity : MonoBehaviour
{
    public GenericInteractionActivity handler;


    void OnTriggerEnter(Collider o) {
        if(o.tag == "FaceCollider") {
            handler.increment();
            Destroy(this.gameObject);
        }
    }
}
