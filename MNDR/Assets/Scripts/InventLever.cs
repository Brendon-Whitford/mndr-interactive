using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventLever : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Inventory; 
    
    void Start()
    {
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(this.transform.localRotation.z);

        if(this.transform.rotation.z >= 0.50)
        {

            Inventory.SetActive(true);
        }
        if (this.transform.localRotation.z < 0.50)
        {
            Inventory.SetActive(false);
        }
    }
}
