using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Vector3 pos;

    public GameObject Inventory;
    public Transform PlayerHead;

    public float spawnDistance = 2;

    public bool hasUpdated = false;

    public void Update()
    {
        // clamping the postions of the Vector3 pos
        pos = transform.localPosition;
        pos.x = Mathf.Clamp(pos.x, 0f, 0.023f);
        pos.y = Mathf.Clamp(pos.y, 0f, 0f);
        pos.z = Mathf.Clamp(pos.z, 0f, 0f);

        // setting the postions of gameObject this is attched to
        transform.localPosition = pos;

        if(pos.x <= 0.015f)
        {
           Inventory.SetActive(false);
           // Inventory.GetComponent<Renderer>().enabled = false;
           // Inventory.GetComponentInChildren<Renderer>().enabled = false;
            hasUpdated = false;
        }
        else if (pos.x >= 0.016)
        {

             Inventory.SetActive(true);
            //Inventory.GetComponentInChildren<Renderer>().enabled = true;
            if (hasUpdated == false)
            {
                needsUpdate();
            }
        }

    }

    public void needsUpdate()
    {
        //updating the positon of the head gameObject
        Inventory.transform.position = PlayerHead.position + new Vector3(PlayerHead.forward.x, 0, PlayerHead.forward.z).normalized * spawnDistance;
        hasUpdated = true;
    }
}
