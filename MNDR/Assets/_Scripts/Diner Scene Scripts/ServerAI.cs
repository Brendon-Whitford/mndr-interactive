using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ServerAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent; //the AI object with a nav mesh agent component
    [SerializeField] private Transform pointsParent; //empty game object holding points
    [SerializeField] private List<Transform> points; //empty game objects in the scene
    private int destPoint = 0; //current patrol point selected

    void Awake()
    {
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
        // Choose the next destination point when the agent gets close to the current one.
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            GotoNextPoint();
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
}