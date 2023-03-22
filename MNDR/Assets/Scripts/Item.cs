using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

