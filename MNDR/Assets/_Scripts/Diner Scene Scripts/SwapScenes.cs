using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script should be put on the food items to change Scene
//The food items should have the XR Grab Interactable Component and On Select run the function
public class SwapScenes : MonoBehaviour
{
    public string sceneToLoad;

    public void ChangeScene() {
            SceneManager.LoadScene(sceneToLoad);
    }
}
