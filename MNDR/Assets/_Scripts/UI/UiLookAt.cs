using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created By Carson McMahan | 03/21/2024 |
 * This script is being used for UI that is shown while hovering over an object.
 */

public class UiLookAt : MonoBehaviour
{
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.Find("Camera Offset").transform;
    }

    void Update()
    {
        // the transform of the object this is attached too will look at the player
        transform.LookAt(playerTransform.position);
    }
}
