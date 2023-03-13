using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public GameObject player;
    public GameObject enterTeleport;
    public GameObject exitTeleport;
    public GameObject sceneTeleport;
    public int x = 0;
    private float playerX;
    private float playerY;
    private float playerZ;
    private float distance;
    private float sceneDist;
<<<<<<< HEAD
=======
    Teleporter teleporter;
>>>>>>> main
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enterTeleport = GameObject.FindGameObjectWithTag("Enter");
        exitTeleport = GameObject.FindGameObjectWithTag("Exit");
        sceneTeleport = GameObject.FindGameObjectWithTag("sceneEnter");


    }

    // Update is called once per frame
    void Update()
    {

        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        playerZ = player.transform.position.z;
        distance = Vector3.Distance(player.transform.position, enterTeleport.transform.position);
        sceneDist = Vector3.Distance(player.transform.position, sceneTeleport.transform.position);
        x++;

        if (x == 20)
        {
            player.transform.position = new Vector3(playerX + 1, playerY, playerZ);
            x = 0;
        }

        if(distance < 1)
        {
            //player.transform.position = new Vector3(exitTeleport.transform.position.x, exitTeleport.transform.position.y+.5f, exitTeleport.transform.position.z);

        }

        if(sceneDist < 1)
        {
            //SceneManager.LoadScene("SampleScene");
        }

    }
}
