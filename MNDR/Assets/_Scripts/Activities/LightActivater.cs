/**
 * LightActivater.cs
 * Author: Jackson Looney
 * Description: Script for light activity interactions. On Collission with the tag "Fire", will trigger an event in the GenericInteractionActivity.cs script
 * Meant to be utilized alongside the GenericInteractionActivity.cs script, if the GameObject LightActivityHandler doesn't have the component GenericInteractionActivity, it will throw errors
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightActivater : MonoBehaviour
{


    //for testing
    public bool activated = false;

    //The Handler for this activity
    public GenericInteractionActivity LightActivityHandler;

    //reference to the light component
    private Light l;
    // Start is called before the first frame update
    void Start()
    {
        
        if(!activated) {
            l = this.GetComponent<Light>();
            if(!activated) {
                l.enabled = false;
            }
        }
    }


    /**
     * OnTriggerEnter
     * GameObject o : Fire effect, to be thrown into the lamp
     */
    void OnTriggerEnter(Collider o) {
        //if the collider has the tag "Fire"
        if(o.tag == "Fire") {
            //Turn on the light component
            l.enabled = true;
            Destroy(o.gameObject);
            
            //If the LightActivityHandler != null
            if(LightActivityHandler) {
                //call increment() on the handler
                LightActivityHandler.increment();
            } else {
                //if the Handler is null or can't be found
                Debug.Log("No Activity Handler Detected");
            }
        }
    }


}
