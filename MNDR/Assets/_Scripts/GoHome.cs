/**
* GoHome
* Author: Aria Strasser
* Description: Very simple script created to solve a small problem. Was
*              originally used for Records in the Jukebox code. Can be
*              called to send an object to its home position.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    public Vector3 homeCoords;

    public void returnHome()
    {
        this.transform.position = homeCoords;
    }
}
