using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

//pause menu that allows the player to change some settings in any scene or return to the main menu, not usable in the main menu - jacob palin

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerPauseMenuSpawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private bool menuActive;
    [SerializeField] private InputActionReference pauseMenuAction;
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject dinerButton;
    [SerializeField] private UnityEngine.SceneManagement.Scene menuScene;

    //copied from hub diner booth script
    private ActionBasedContinuousMoveProvider conMovement;
    private TeleportationProvider telportMovement;
    bool isContinuouse;
    bool isTeleport;

    private void Awake()
    {
        menuScene = SceneManager.GetSceneByBuildIndex(0);
        MenuVisibility(menuActive = false);
        playerPauseMenuSpawnPoint = GameObject.FindGameObjectWithTag("Pause");

        DontDestroyOnLoad(this);

        player = GameObject.FindGameObjectWithTag("Player");

        //copied from hub diner booth script
        conMovement = player.GetComponent<ActionBasedContinuousMoveProvider>();
        telportMovement = player.GetComponent<TeleportationProvider>();
        CheckMovementType();
    }

    private void Update()
    {
        //since the player and pause menu are being destroyed when returning to the main menu, you need to grab these again unless you unload the main menu scene after moving to another scene
        if (playerPauseMenuSpawnPoint == null)
        {
            playerPauseMenuSpawnPoint = GameObject.FindGameObjectWithTag("Pause");
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //makes pause menu work in every scene except main menu
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            //added an action to the left controller menu button, find that by going into XRI > XR Interaction Toolkit > 2.0.3 > Starter Assets > XRI Default Input Actions, double click the input actions to bring up a new window, under XRI LeftHand Interaction there is an option called pause menu
            pauseMenuAction.action.performed += cxt => SpawnPauseMenu();
        }
    }

    
    public void SpawnPauseMenu()
    {
        transform.position = playerPauseMenuSpawnPoint.transform.position;
        transform.rotation = playerPauseMenuSpawnPoint.transform.rotation;

        if(SceneManager.GetActiveScene() != menuScene)
        {
            dinerButton.SetActive(true);
        }
        else if(SceneManager.GetActiveScene() == menuScene)
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
            if (isContinuouse)
                conMovement.enabled = true;
            else if (isTeleport)
                telportMovement.enabled = true;
        }
    }
    public void GoToMenuScene()
    {
        //destroy old copies of everything necessary before returning to the main menu
        Destroy(FindObjectOfType<DontDestroy>().gameObject);
        Destroy(FindObjectOfType<EventSystem>().gameObject);
        Destroy(gameObject, .1f); //objects can't destroy themselves immediately so you need to add a delay
        SceneManager.LoadScene(0);
    }

    //copied from hub diner booth script
    private void MenuVisibility(bool visible)
    {
        mainPage.SetActive(visible);
        panel.SetActive(visible);
        settingsPage.SetActive(false);
    }
    private void CheckMovementType()
    {
        isContinuouse = conMovement.enabled;
        isTeleport = telportMovement.enabled;
    }
}