using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zipperClamp : MonoBehaviour
{
    public GameObject zipper;
    public GameObject Inventory;
    public Transform zipperPos;
    float minX = 0f;
    float maxX = 0.03f;
    // Get the object's local position

    // Clamp the local x-position to the range between minX and maxX
    //zipper.localPosition.x = Mathf.Clamp(localPosition.x, minX, maxX);

    // Set the object's local position to the clamped value
    //transform.localPosition = localPosition;

    // Start is called before the first frame update
    void Start()
    {

      
      
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localPos = zipperPos.localPosition;

        // Clamp the local x-position to the range between minX and maxX
        localPos.x = Mathf.Clamp(localPos.x, minX, maxX);
        localPos.y = Mathf.Clamp(localPos.y, 0f, 0f);
        localPos.z = Mathf.Clamp(localPos.z, 0f, 0f);

        // Set the object's local position to the clamped value
        zipperPos.localPosition = localPos;

        if(zipper.transform.localPosition.x >= 0.025)
        {
            Inventory.SetActive(true);
        }
        else
        {
            Inventory.SetActive(false);
        }
    }
}
