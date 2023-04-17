using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ParentItem : MonoBehaviour

{
    public XRSocketInteractor socket;
    public GameObject ParentObj;
    public GameObject item;
    //creating what will be the parent of the new object
    private void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }
    public void parented()
    {
        item = socket.selectTarget.gameObject;
        item.transform.SetParent(ParentObj.transform);
        item.gameObject.GetComponent<Rigidbody>().isKinematic = false;
       

    }

     public void deparented()
    {
        item.transform.SetParent(null);
        item.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
