using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] private GameObject playerPauseMenuSpawnPoint;
    [SerializeField] private GameObject howToPlayUI;
    private static HowToPlayUI instance;

    void Awake()
    {
        howToPlayUI.SetActive(true);
        //so it doesn't pop up again after coming back to hub
        DontDestroyOnLoad(this); 
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        playerPauseMenuSpawnPoint = GameObject.FindGameObjectWithTag("Pause");
        playerPauseMenuSpawnPoint.GetComponentInParent<LocomotionSystem>().enabled = false;
        transform.position = playerPauseMenuSpawnPoint.transform.position;
        transform.rotation = playerPauseMenuSpawnPoint.transform.rotation;
    }

    public void ContinueButton()
    {
        playerPauseMenuSpawnPoint.GetComponentInParent<LocomotionSystem>().enabled = true;
        howToPlayUI.SetActive(false);
    }
}