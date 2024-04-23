using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the dont destroy script for the player only, any other instances of this script in the scene will be deleted. - jacob palin

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject); //copies are deleted when activating the button inside the pause menu to return to the main menu
    }
}