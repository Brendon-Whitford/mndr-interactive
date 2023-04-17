using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    ActionBasedController controller;
    public Hand hand;
    
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }
   
}
