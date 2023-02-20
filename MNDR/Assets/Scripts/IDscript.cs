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
    public bool iWasCollected = false;
    /* public void sendIDToSpawn()
      {
          Debug.Log(buttonID);
          itemSpawnerSC.compareINT = buttonID;
          this.gameObject.GetComponent<Button>().interactable = false;
      }*/
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
