using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerPauseMenuSpawnPoint;
    [SerializeField] private bool menuActive;
    [SerializeField] private InputActionReference pauseMenuAction;

    private void Awake()
    {
        MenuVisibility(menuActive = false);
        playerPauseMenuSpawnPoint = GameObject.FindGameObjectWithTag("Pause");
    }

    private void Update()
    {
        pauseMenuAction.action.performed += cxt => SpawnPauseMenu();
        
    }

    public void SpawnPauseMenu()
    {
        transform.position = playerPauseMenuSpawnPoint.transform.position;
        transform.rotation = playerPauseMenuSpawnPoint.transform.rotation;

        if (menuActive == false)
        {
            playerPauseMenuSpawnPoint.GetComponentInParent<LocomotionSystem>().enabled = false;
            MenuVisibility(menuActive = true);
        }
        else if (menuActive == true)
        {
            playerPauseMenuSpawnPoint.GetComponentInParent<LocomotionSystem>().enabled = true;
            MenuVisibility(menuActive = false);
        }
    }

    private void MenuVisibility(bool visible)
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(visible);
        }
    }
}