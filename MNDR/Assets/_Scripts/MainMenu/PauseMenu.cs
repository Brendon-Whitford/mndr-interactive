using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerPauseMenuSpawnPoint;
    [SerializeField] private bool menuActive;
    [SerializeField] private InputActionReference pauseMenuAction;
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject dinerButton;
    [SerializeField] private UnityEngine.SceneManagement.Scene hubScene;
    private static PauseMenu instance;

    private void Awake()
    {
        hubScene = SceneManager.GetSceneByBuildIndex(1);
        MenuVisibility(menuActive = false);
        playerPauseMenuSpawnPoint = GameObject.FindGameObjectWithTag("Pause"); 
        
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            pauseMenuAction.action.performed += cxt => SpawnPauseMenu();
        }
    }

    public void SpawnPauseMenu()
    {
        transform.position = playerPauseMenuSpawnPoint.transform.position;
        transform.rotation = playerPauseMenuSpawnPoint.transform.rotation;

        if(SceneManager.GetActiveScene() != hubScene)
        {
            dinerButton.SetActive(true);
        }
        else if(SceneManager.GetActiveScene() == hubScene)
        {
            dinerButton.SetActive(false);
        }

        if (menuActive == false)
        {
            MenuVisibility(menuActive = true);
        }
        else if (menuActive == true)
        {
            MenuVisibility(menuActive = false);
        }
    }

    private void MenuVisibility(bool visible)
    {
        mainPage.SetActive(visible);
        panel.SetActive(visible);
        settingsPage.SetActive(false);
    }
}