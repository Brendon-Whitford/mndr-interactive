using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class HandAnimator : MonoBehaviour
{
    [SerializeField] private InputAction LTriggerAction;
    [SerializeField] private InputAction RTriggerAction;
    [SerializeField] private InputAction LGripAction;
    [SerializeField] private InputAction RGripAction;
    //[SerializeField] private InputAction GripAction;
    public InputActionAsset inputaction;
    public Animator anim;

    private void Start()
    {
        LTriggerAction = inputaction.FindActionMap("XRI LeftHand Interaction").FindAction("Activate Value");
        LTriggerAction.Enable();
       // LTriggerAction.performed += LtriggerAnim;
       // LTriggerAction.canceled += LtriggerAnimC;

        RTriggerAction = inputaction.FindActionMap("XRI RightHand Interaction").FindAction("Activate Value");
        RTriggerAction.Enable();
       // RTriggerAction.performed += RtriggerAnim;
       // RTriggerAction.canceled += RtriggerAnimC;

        LGripAction = inputaction.FindActionMap("XRI LeftHand Interaction").FindAction("Select Value");
        LGripAction.Enable();
       // LGripAction.performed += LGripAnim;
        //LGripAction.canceled += LGripAnimC;

        RGripAction = inputaction.FindActionMap("XRI RightHand Interaction").FindAction("Select Value");
        RGripAction.Enable();
       // RGripAction.performed += RGripAnim;
       // RGripAction.canceled += RGripAnimC;
        //anim = GetComponent<Animator>();
    }
    /* public void LtriggerAnim(InputAction.CallbackContext context)
    {
        anim.SetBool("RHPinch", true);
    }
    public void RtriggerAnim(InputAction.CallbackContext context)
    {
        anim.SetBool("LHPinch", true);
    }
    public void LGripAnim(InputAction.CallbackContext context)
    {
        anim.SetBool("LHClose", true);
    }
    public void RGripAnim(InputAction.CallbackContext context)
    {
        anim.SetBool("RHClose", true);
    }
    public void LtriggerAnimC(InputAction.CallbackContext context)
    {
        anim.SetBool("RHPinch", false);
    }
    public void RtriggerAnimC(InputAction.CallbackContext context)
    {
        anim.SetBool("LHPinch", false);
    }
    public void LGripAnimC(InputAction.CallbackContext context)
    {
        anim.SetBool("LHClose", false);
    }
    public void RGripAnimC(InputAction.CallbackContext context)
    {
        anim.SetBool("RHClose", false);
    }*/
    // Update is called once per frame
    void Update()
    {
       // LTriggerAction.ReadValue<float>();
       // RTriggerAction.ReadValue<float>();
       // LGripAction.ReadValue<float>();
       // RGripAction.ReadValue<float>();
        //float triggerValue = TriggerAction.action.ReadValue<float>();
        //float gripValue = GripAction.action.ReadValue<float>();
        //bool TriggerBool = TriggerAction.action.ReadValue<bool>();
        //bool GripBool = GripAction.action.ReadValue<bool>();
        anim.SetFloat("RHPinchF", RGripAction.ReadValue<float>());
        anim.SetFloat("LHPinchF", LGripAction.ReadValue<float>());
        anim.SetFloat("RHCloseF", RTriggerAction.ReadValue<float>());
        anim.SetFloat("LHCloseF", LTriggerAction.ReadValue<float>());
        // anim.SetBool("LHPinch", true);
        //anim.SetFloat("LHClose", gripValue);
        //anim.SetBool("RHPinch", true);
    }
}
