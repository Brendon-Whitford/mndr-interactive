using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

//tutorial UI that pops up the first time the player enters the diner/nature/club scenes - jacob palin

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject menuSpawnPoint;
    [SerializeField] private GameObject howToPlayUI;
    [SerializeField] private float timeToWait = 1f;
    private bool activateTimer;

    private static HowToPlayUI instance;

    //copied from hub diner booth script
    private ActionBasedContinuousMoveProvider conMovement;
    private TeleportationProvider telportMovement;
    bool isContinuouse;
    bool isTeleport;

    private bool natureFirstTime;
    private bool clubFirstTime;

    void Awake()
    {
        //so it doesn't pop up again after coming back to hub
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            activateTimer = true;
            menuSpawnPoint = GameObject.FindGameObjectWithTag("Pause");
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
            Destroy(gameObject, .1f); //objects can't destroy themselves immediately so you need to add a delay
        }
    }

    private void Update()
    {
        //since the player is being destroyed when returning to the main menu, you need to grab these again unless you unload the main menu scene after moving to another scene

        if (menuSpawnPoint == null)
        {
            menuSpawnPoint = GameObject.FindGameObjectWithTag("Pause");
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (conMovement == null)
        {
            conMovement = player.GetComponent<ActionBasedContinuousMoveProvider>();
        }
        if (telportMovement == null)
        {
            telportMovement = player.GetComponent<TeleportationProvider>();
        }

        //wait for the player to move to the spawn point before putting the UI in front
        if (activateTimer == true)
        {
            Timer();
        }

        //pop up for first time in each scene, probably a better way to do it for more scenes in the future with a for loop and a bool list that grabs the number of current scenes then every time you enter a new scene it compares it to the bool list plus 1 to build index number, plus 1 because main menu exists
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2) && natureFirstTime == true)
        {
            natureFirstTime = false;
            activateTimer = true;
            DisableMovement();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3) && clubFirstTime == true)
        {
            clubFirstTime = false;
            activateTimer = true;
            DisableMovement();
        }
    }

    private void Timer()
    {
        timeToWait -= Time.deltaTime;
        if (timeToWait <= 0)
        {
            activateTimer = false;
            transform.position = menuSpawnPoint.transform.position;
        }
    }

    private void DisableMovement()
    {
        howToPlayUI.SetActive(true);
        CheckMovementType();
        conMovement.enabled = false;
        telportMovement.enabled = false;
    }
    //copied from hub diner booth script
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