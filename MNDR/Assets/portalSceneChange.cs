/**
 * portalSceneChange.cs
 * Author: Jackson Looney
 * Description: this script, upon being triggered, will send the player to the next scene in the stack
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class portalSceneChange : MonoBehaviour
{
    

    //If necessary, this can be modified to send the player to a specific scene based on an input parameter in the inspector
    void OnTriggerEnter() {
        //since the cathedral scene is index 0, index 1 will be the next scene in the stack
        SceneManager.LoadScene(1);
    }
}
