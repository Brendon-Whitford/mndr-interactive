/**
* AudioSliderController
* Author: Hayden Dalton
* Description: The purpose of this script is to control the menu, its pages,
*              Toggles for movement and turning as well as starting the next scene
*              or quiting the game. These functions are just called with On Value Changed event
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header ("Pages")]
    public GameObject pageOne;
    public GameObject pageTwo;  

    public void Awake() {
        pageOne.SetActive(true);
        pageTwo.SetActive(false);
    }

    //Chooses which seen to go on, set this for the start button
    public void GoToHub(){
        SceneManager.LoadScene(0);
    }

    public void Quit(){
        Application.Quit();
    }

    public void GoToSettings(){
        pageOne.SetActive(false);
        pageTwo.SetActive(true);
    }

    public void GoToMainMenu(){
        pageOne.SetActive(true);
        pageTwo.SetActive(false);
    }
}
