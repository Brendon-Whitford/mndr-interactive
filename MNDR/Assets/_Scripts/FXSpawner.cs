/**
* FXSpawner
* Author: Jackson Looney
* Description: allows for the spawning of a selected (with randomized parameters) effect within the bounds specified
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FXSpawner : MonoBehaviour
{

    [Header("The Effect to spawn")]
    public GameObject effect;
    [Header("Number of effects to spawn")]
    public int numberOfSpawns;

    [Header("The Bounds for the spawn area")]
    public float xBound;
    public float yBound;
    public float zBound;


    private float xFloat = 1;
    private float yFloat = 1;
    private float zFloat = 1;

    /*private Vector3 spawnPos;*/
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfSpawns; i++) {
            //Random Positioning within bounds of the spawn area
            xFloat = Random.Range(this.transform.position.x - xBound, this.transform.position.x + xBound);
            yFloat = Random.Range(this.transform.position.y - yBound, this.transform.position.y + yBound);
            zFloat = Random.Range(this.transform.position.z - zBound, this.transform.position.z  + zBound);

            Vector3 spawnPos = new Vector3(xFloat, yFloat, zFloat);

            //Instantiate effect
            Instantiate(effect, spawnPos, effect.transform.rotation);
        }
    }


    // void Update() {
    //     OnDrawGizmos();
    // }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(xBound, yBound, zBound));
        
    }

}
