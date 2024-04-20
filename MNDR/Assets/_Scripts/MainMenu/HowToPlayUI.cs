using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject menuSpawnPoint;
    [SerializeField] private GameObject howToPlayUI;
    [SerializeField] private float timeToWait = 1f;
    private bool activateTimer;

    private static HowToPlayUI instance;

    private ActionBasedContinuousMoveProvider conMovement;
    private TeleportationProvider telportMovement;
    bool isContinuouse;
    bool isTeleport;

    private bool natureFirstTime;
    private bool clubFirstTime;
    private bool hubFirstTime;

    void Awake()
    {
        //so it doesn't pop up again after coming back to hub
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            activateTimer = true;
            menuSpawnPoint = GameObject.FindGameObjectWithTag("Pause");
            player = GameObject.FindGameObjectWithTag("Player");
            instance = this;
            conMovement = player.GetComponent<ActionBasedContinuousMoveProvider>();
            telportMovement = player.GetComponent<TeleportationProvider>();
            DisableMovement();
            natureFirstTime = true;
            clubFirstTime = true;
            hubFirstTime = true;
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(this);
        }
    }

    private void Start()
    {
        CheckMovementType();
    }

    private void Update()
    {
        if (activateTimer == true)
        {
            Timer();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) && hubFirstTime == true)
        {
            hubFirstTime = false;
            activateTimer = true;
            DisableMovement();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2) && natureFirstTime == true)
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
        if (isContinuouse)
            conMovement.enabled = false;
        else if (isTeleport)
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