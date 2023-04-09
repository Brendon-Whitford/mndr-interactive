using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    [SerializeField] private InputActionProperty TriggerAction;
    [SerializeField] private InputActionProperty GripAction;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //  float triggerValue = TriggerAction.action.ReadValue<float>();
        // float gripValue = GripAction.action.ReadValue<float>();
        bool TriggerBool = TriggerAction.action.ReadValue<bool>();
        bool GripBool = GripAction.action.ReadValue<bool>();
        // anim.SetFloat("Trigger", triggerValue);
        anim.SetBool("LHPinch", true);
       // anim.SetFloat("Grip", gripValue);
        anim.SetBool("RHPinch", true);
    }
}
