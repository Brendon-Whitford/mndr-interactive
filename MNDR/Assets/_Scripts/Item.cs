using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is a script for objects that can be collected by the player and placed in the inventory.

public  class Item: MonoBehaviour
{
    public GameObject thisButton;
    public int IDnumber;
    //public Button buttenable;
    //public List<GameObject> Buttons = new List<GameObject>();

    public bool Collected;
    private void Start()
    {
      // buttenable = thisButton.GetComponent<Button>();
    }



    private void OnDestroy()
    {

      //  buttenable.interactable = true;
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
        // if the player or the hand collide with the item then it will be added to the inventory
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerHands")
        {
            
            thisButton.GetComponent<IDscript>().checkCollected();
            thisButton.GetComponent<IDscript>().iWasCollected = true;
        }
        if (collision.gameObject.tag == "spawnBox")
        {
            if (collision.gameObject.tag == "Item")
            {
                Destroy(this.gameObject);
                //thisButton.GetComponent<IDscript>().iWasCollected = true;
            }
        }
    }

    // same thing but as a trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerHands")
        {
            thisButton.GetComponent<IDscript>().checkCollected();
            thisButton.GetComponent<IDscript>().iWasCollected = true;
        }
        if (other.gameObject.tag == "spawnBox")
        {
            if (other.gameObject.tag == "Item")
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void destroyItem()
    {
       
        // thisButton.GetComponent<Button>().interactable = true;
       
            Destroy(this.gameObject);
        
        

    }
}

