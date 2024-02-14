/**
* SocketManager
* Author: Aria Strasser
* Description: This script goes on an empty GameObject. It will need an AudioSource.
*              The AudioSource should have a group (the stem you want to play) and a
*              clip of the audio you want played. Play on Awake and Loop must be checked.
*              Takes an integer for how many total sockets you want
*              
*              When all correct orbs are placed on their pedestals, it will start playing
*              the full song.
*              
*              Works in conjunction with AudioOrb and OrbPedestal scripts
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketManager : MonoBehaviour
{
    public int correctSockets = 0;
    public int totalSockets = 3;

    public bool canBeActivated = true;

    public void CheckSockets()
    {
        if (correctSockets == totalSockets)
        {
            // All sockets have the correct orb
            Debug.Log("Success!! All sockets have the correct interactable!");
            canBeActivated = false;
            // Add an audio listener and have its audio start here
        }
    }
}
