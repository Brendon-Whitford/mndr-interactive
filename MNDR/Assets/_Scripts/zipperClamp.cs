using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An early idea for the game was to have a waist bag with a zipper that the player opens to open their inventory. 
// This controls the zipper.

public class zipperClamp : MonoBehaviour
{
    public GameObject zipper;
    public GameObject Inventory;
    public Transform zipperPos;
    public float zipX;
    public float zipY;
    public float zipZ;
     float minX = 0f;
    float maxX = 0.03f;

    float inX;
    float inY;
    float inZ;
    public float addX = 0;
    public float addY = 0;
    public float addZ = 0;


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
        addX = 1;
        addY = 0.5f;
        addZ = -.3f;

        // Clamp the local x-position to the range between minX and maxX
        localPos.x = Mathf.Clamp(localPos.x, minX, maxX);
        localPos.y = Mathf.Clamp(localPos.y, 0f, 0f);
        localPos.z = Mathf.Clamp(localPos.z, 0f, 0f);

        // Set the object's local position to the clamped value
        zipperPos.localPosition = localPos;

        if(zipper.transform.localPosition.x >= 0.025)
        {
            inX = this.transform.position.x;
            inY = this.transform.position.y;
            inZ = this.transform.position.z;
            Inventory.transform.position = new Vector3(inX + addX, inY + addY, inZ + addZ);

            Inventory.SetActive(true);
        }
        else
        {
            Inventory.SetActive(false);
        }
    }
}
