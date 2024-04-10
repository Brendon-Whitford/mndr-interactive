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
    [SerializeField] private GameObject player;
    [SerializeField] private bool menuActive;
    [SerializeField] private InputActionReference pauseMenuAction;
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject dinerButton;
    [SerializeField] private UnityEngine.SceneManagement.Scene menuScene;
    private static PauseMenu instance;

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
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        conMovement = player.GetComponent<ActionBasedContinuousMoveProvider>();
        telportMovement = player.GetComponent<TeleportationProvider>();
        CheckMovementType();
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