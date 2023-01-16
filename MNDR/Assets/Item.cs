using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Item: MonoBehaviour
{
    public GameObject thisButton;
    public int IDnumber;
    //public List<GameObject> Buttons = new List<GameObject>();
    
    public bool Collected;

   

    
    private void OnDestroy()
    {
       
        thisButton.GetComponent<Button>().interactable = true;
    }

    /*  private void OnTriggerStay(Collider other)
      {
          if(other.gameObject.tag == "spawnBox")
          {
              if(other.gameObject.tag == "Item")
              {
                  Destroy(this.gameObject);
              }
          }
      }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerHands")
        {
            Collected = true;
            thisButton.GetComponent<IDscript>().checkCollected();
        }
        if (collision.gameObject.tag == "spawnBox")
        {
            if (collision.gameObject.tag == "Item")
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void destroyItem()
    {
        Destroy(this.gameObject);

    }
}

