/**
* PlayerSpawnPoint
* Author: Hayden Dalton
* Description: Used to spawn the player when they load into the scene
* Just need to place an empty gameobject you assign and the player will spawn at that position.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    private void Awake(){
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null && spawnPoint != null){
            player.transform.SetPositionAndRotation(spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else {
            Debug.Log("Either player or spawnPoint is not is Null");
        }
    }
}
