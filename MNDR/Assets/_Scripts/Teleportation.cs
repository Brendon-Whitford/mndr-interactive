using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using UnityEngine.SceneManagement;

// Deprecated
// Used for moving the player between an enter/exit teleport

public class Teleportation : MonoBehaviour
{
    public GameObject player;
    public GameObject enterTeleport;
    public GameObject exitTeleport;
    public GameObject sceneTeleport;
    private float playerX;
    private float playerY;
    private float playerZ;
    private float distance;
    private float sceneDist = 100;
    //Teleporter teleporter;
    
    void Start()
    {
        //Assigns the player object and portal object to variables
        player = GameObject.FindGameObjectWithTag("Player");
        //enterTeleport = GameObject.FindGameObjectWithTag("PortalEnter");
        //exitTeleport = GameObject.FindGameObjectWithTag("PortalExit");
        sceneTeleport = GameObject.FindGameObjectWithTag("PortalEnter");


    }

    void Update()
    {

        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        playerZ = player.transform.position.z;
        //distance = Vector3.Distance(player.transform.position, enterTeleport.transform.position);

        //Checks to see if there is an portal object in the map
        if (sceneTeleport != null)
        {
            sceneDist = Vector3.Distance(player.transform.position, sceneTeleport.transform.position);
        }  

        /*if(distance < 1)
        {
            //player.transform.position = new Vector3(exitTeleport.transform.position.x, exitTeleport.transform.position.y+.5f, exitTeleport.transform.position.z);

        }*/

        if(sceneDist < 1)
        {
            //If the player is close to the portal, initialize the brain maze scene
            Debug.Log("Got Here");
            SceneManager.LoadScene("2 Brain Maze");
        }

    }
}
