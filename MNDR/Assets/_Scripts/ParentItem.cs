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
        // grabbing the socket component
        socket = GetComponent<XRSocketInteractor>();
    }

    public void parented()
    {
        // selecting the target
        item = socket.selectTarget.gameObject;

        // making it a parent
        item.transform.SetParent(ParentObj.transform);

        // setting isKinematic to false
        item.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void deparented()
    {
        // setting parent as null
        item.transform.SetParent(null);

        // setting isKinematic to true
        item.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
