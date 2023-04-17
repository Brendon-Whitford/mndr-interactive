using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeCloth : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
