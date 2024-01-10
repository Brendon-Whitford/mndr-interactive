using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayCase : MonoBehaviour
{
    public bool itemInside;
    public bool ranOnce;
    public GameObject lastSpawned;
   
    private void OnTriggerStay(Collider other)
    {
        // detecting the object with tag of "Item"
        if (other.gameObject.tag == "Item")
        {
            // setting bool to true
            itemInside = true;
            //other.gameObject.GetComponent<Rigidbody>().isKinematic = true ;

            // setting lastSpawned = to the object detect with tag of "Item"
            lastSpawned = other.gameObject;
        }
        
    }

    // setting the bool to false
    private void OnTriggerExit(Collider other)
    {
        itemInside = false;
    }
}
