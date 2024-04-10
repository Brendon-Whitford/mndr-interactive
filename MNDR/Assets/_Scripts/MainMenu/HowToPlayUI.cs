using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject howToPlayUI;
    private static HowToPlayUI instance;

    private ActionBasedContinuousMoveProvider conMovement;
    private TeleportationProvider telportMovement;
    bool isContinuouse;
    bool isTeleport;

    private bool natureFirstTime;
    private bool clubFirstTime;

    void Awake()
    {
        //so it doesn't pop up again after coming back to hub
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            instance = this;
            conMovement = player.GetComponent<ActionBasedContinuousMoveProvider>();
            telportMovement = player.GetComponent<TeleportationProvider>();
            DisableMovement();
            natureFirstTime = true;
            clubFirstTime = true;
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(this);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2) && natureFirstTime == true)
        {
            natureFirstTime = false;
            DisableMovement();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3) && clubFirstTime == true)
        {
            clubFirstTime = false;
            DisableMovement();
        }
    }

    private void DisableMovement()
    {
        howToPlayUI.SetActive(true);
        CheckMovementType();
        conMovement.enabled = false;
        telportMovement.enabled = false;
    }

    private void CheckMovementType()
    {
        isContinuouse = conMovement.enabled;
        isTeleport = telportMovement.enabled;
    }

    public void ContinueButton()
    {
        if (isContinuouse)
            conMovement.enabled = true;
        else if (isTeleport)
            telportMovement.enabled = true;
        howToPlayUI.SetActive(false);
    }
}