using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Billboard script. Put it on an object to make it always look at the player.

public class LookAt : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
