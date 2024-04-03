using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Staircase : MonoBehaviour
{
    [SerializeField] private string clubSceneName;
    [SerializeField] private LayerMask staircaseLayer; 
    [SerializeField] private float interactDistance;

    private Transform player;
    private Transform rightController;

    // Start is called before the first frame update
    void Awake()
    {
        rightController = GameObject.Find("RightHand Controller").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
                SceneManager.LoadScene(clubSceneName);
            }
        }
    }
}
