using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Staircase : MonoBehaviour
{
    [SerializeField] private int sceneID;
    [SerializeField] private LayerMask staircaseLayer; 
    [SerializeField] private float interactDistance;
    [SerializeField] private GameObject hoverUI;

    private Transform rightController;

    // Start is called before the first frame update
    void Awake()
    {
        rightController = GameObject.Find("RightHand Controller").transform;
    }

    private void Start()
    {
        hoverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("RightController_A"))
        {
            // creating a raycast out of the right controller
            Ray rightControllerRay = new(rightController.position, rightController.forward);

            if (Physics.Raycast(rightControllerRay, interactDistance, staircaseLayer))
            {
                SceneManager.LoadScene(sceneID);
            }
        }
    }

    private void FixedUpdate()
    {
        // creating a raycast out of the right controller
        Ray rightControllerRay = new(rightController.position, rightController.forward);

        if (Physics.Raycast(rightControllerRay, interactDistance, staircaseLayer))
        {
            hoverUI.SetActive(true);
        }
        else
        {
            hoverUI.SetActive(false);
        }
    }
}
