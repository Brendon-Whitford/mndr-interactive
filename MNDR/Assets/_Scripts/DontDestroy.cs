using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to any parent gameobject and it will not be destroyed on the start up of new scene.

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
