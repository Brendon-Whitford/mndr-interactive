using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectSpawner : MonoBehaviour
{
    public GameObject spawnDisplay;
    //public GameObject spawnItem;
    public int compareINT;
    private displayCase displaySC;

    [Header("List of Spawnables & Spawned Items")]
    public List<ItemToSpawn> spawnables = new List<ItemToSpawn>();
    public List<GameObject> spawnedItems = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        spawnDisplay.GetComponent<Collider>();
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    public void SpawnItem(/*int IDpass*/)
    {
       // grabbing each item in spawnables list
        foreach (var item in spawnables)
        {
            // comapring the index, isCollected, and isSpawned
            if(item.ID == compareINT &&  item.isCollected == true && item.isSpawned == false )
            {
                Debug.Log(compareINT);
                /* if(displaySC.itemInside == true)
                 {

                 }*/

                // instantiated those items
               Instantiate(item.enemyPrefab,spawnDisplay.transform.position,spawnDisplay.transform.localRotation);
                //spawnedItems.Add(newItem);

                // setting the bool back to true
                item.isSpawned = true;
            }
        }
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class ItemToSpawn
{
    public GameObject enemyPrefab;
    public int ID;
    public bool isCollected;
    public bool isSpawned;
}
