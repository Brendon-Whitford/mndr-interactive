using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ServerAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent; //the AI object with a nav mesh agent component
    [SerializeField] private Transform pointsParent; //empty game object holding points
    [SerializeField] private List<Transform> points; //empty game objects in the scene
    [SerializeField] private Transform deliveryPoint; //empty game object that tells AI to go to table after player orders
    private int destPoint = 0; //current patrol point selected
    public bool hasOrdered; //Triggered when player orders from menu
    //Grab all the food items needed for how many scenes we need
    [SerializeField] private GameObject brainFood;
    [SerializeField] private GameObject cathedralFood;
    [SerializeField] private GameObject hubFood;
    private GameObject currentFood;

    private Booth booth;

    void Awake()
    {
        hubFood.SetActive(false);
        cathedralFood.SetActive(false);
        brainFood.SetActive(false);
        hasOrdered = false;

        booth = FindObjectOfType<Booth>();

        //grabs all the patrolling points
        foreach(Transform child in pointsParent.transform)
        {
            points.Add(child);
        }
        navMeshAgent = GetComponent<NavMeshAgent>(); //grabs nav mesh component

        navMeshAgent.autoBraking = true; // slows down when approaching a point

        GotoNextPoint();
    }

    void Update()
    {
        //When food is ordered the AI goes to the booth, and the current food is the same as what they order
        if (hasOrdered) {
            MoveToBooth(currentFood);
        } else{
            // Choose the next destination point when the agent gets close to the current one.
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Count == 0)
            return;

        //picks random point to move to
        destPoint = Random.Range(0, points.Count);

        // Set the agent to go to the currently selected destination.
        navMeshAgent.destination = points[destPoint].position;
    }

    void MoveToBooth(GameObject food){
        //Sets the currentFood to what dish was ordered from the menu
        currentFood = food;

        // checking to see if player is sitting
        if(booth.isSitting == false)
        {
            // play voice line
            Debug.Log("Please take a seat before ordering.");
        }
        else
        {
            navMeshAgent.destination = deliveryPoint.position;

            //If the AI makes it to the booth show the food item
            if (navMeshAgent.remainingDistance < 0.1f)
            {
                if (currentFood != null)
                {
                    currentFood.SetActive(true);
                }
            }
        }
    }

    //Make sure each button on the menus On Click () function points to one of these functions
    public void HasOrderedBrainMaze(){
        hasOrdered = true;
        MoveToBooth(brainFood);
    }

    public void HasOrderedCathedral(){
        hasOrdered = true;
        MoveToBooth(cathedralFood);
    }

    public void HasOrderedHub(){
        hasOrdered = true;
        MoveToBooth(hubFood);
    }
}