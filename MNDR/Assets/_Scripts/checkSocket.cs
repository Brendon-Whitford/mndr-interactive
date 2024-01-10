using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class checkSocket : MonoBehaviour
{
    public XRSocketInteractor socket;
   
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void socketCheck()
    {
        Debug.Log("ItemDetected");

        // creating a gameObject for socket
        GameObject itemSocketed = socket.selectTarget.gameObject;
        //Debug.Log(itemSocketed);

        // destroying it
        Destroy(itemSocketed);
        //Destroy(itemSocketed);
       // DontDestroyOnLoad(item);
        //Debug.Log(item);
       
    
    }
}