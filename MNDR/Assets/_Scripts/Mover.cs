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
        pos = transform.localPosition;
        pos.x = Mathf.Clamp(pos.x, 0f, 0.023f);
        pos.y = Mathf.Clamp(pos.y, 0f, 0f);
        pos.z = Mathf.Clamp(pos.z, 0f, 0f);
        transform.localPosition = pos;

        if(pos.x <= 0.015f)
        {
            Inventory.SetActive(false);
            hasUpdated = false;
        }
        else if (pos.x >= 0.016)
        {
            
            Inventory.SetActive(true);
            if(hasUpdated == false)
            {
                needsUpdate();
            }
        }

    }

    public void needsUpdate()
    {
        Inventory.transform.position = PlayerHead.position + new Vector3(PlayerHead.forward.x, 0, PlayerHead.forward.z).normalized * spawnDistance;
        hasUpdated = true;
    }
}
