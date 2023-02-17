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

    // Update is called once per frame
   public void socketCheck()
    {
        
        Debug.Log("ItemDetected");
        

        GameObject itemSocketed = socket.selectTarget.gameObject;
        //Debug.Log(itemSocketed);
        
        itemSocketed.GetComponent<Item>().destroyItem();
        //Destroy(itemSocketed);
       // DontDestroyOnLoad(item);
        //Debug.Log(item);
       
       
            
            
           
        
    }
   
}
