using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When the player spawns an item into the world from their inventory this script gets called.

public class itemStart : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
