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
        if (other.gameObject.tag == "Item")
        {
            itemInside = true;
            //other.gameObject.GetComponent<Rigidbody>().isKinematic = true ;
            lastSpawned = other.gameObject;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        
            itemInside = false;
        
    }

    

    private void Update()
    {
        
    }


}
