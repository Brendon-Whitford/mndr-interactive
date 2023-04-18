using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDscript : MonoBehaviour
{
    // public int buttonID = 0;
    //public ItemSelectSpawner itemSpawnerSC;
    public GameObject itemToSpawn;
    public GameObject recentItem;
    public GameObject spawnDisplay;
    public GameObject card;
    public bool check = false;
    public bool iWasCollected = false;
    public bool activeVar = false;
    /* public void sendIDToSpawn()
      {
          Debug.Log(buttonID);
          itemSpawnerSC.compareINT = buttonID;
          this.gameObject.GetComponent<Button>().interactable = false;
      }*/

    /* public void Start()
     {
         this.GetComponent<Button>().interactable = false;
         iWasCollected = false;

     }*/

    public void Awake()
    {

    }

    public void Update()
    {
        //All cards are spawned in the scrollview but set inActive. This code turns them on once they've been interacted and then displays them in the inventory
        /*if(activeVar == false)
        {
            if(iWasCollected == true)
            {
                this.gameObject.SetActive(true);
            }
        }*/
    }


    //Links to the XR interactable on the cards in the scene. This sets this individual card's button to active(unhidden) revealing it in the inventory. This only applies to cards placed in the scene, not instanciated by code.
    public void setActive(GameObject active)
    {
        active.gameObject.SetActive(true);
    }

    public void spawnItem()
    {
        recentItem = Instantiate(itemToSpawn, spawnDisplay.transform.position, spawnDisplay.transform.rotation);
        this.GetComponent<Button>().interactable = false;
    }

    public void destroyRecent()
    {
        this.GetComponent<Button>().interactable = true;
        Destroy(recentItem);
    }
    public void checkCollected()
    {
       
             this.gameObject.GetComponent<Button>().interactable = true;
        
    }

    private void FixedUpdate()
    {
       if(recentItem == null && iWasCollected == true)
        {
            this.GetComponent<Button>().interactable = true;
        }
    }
}
