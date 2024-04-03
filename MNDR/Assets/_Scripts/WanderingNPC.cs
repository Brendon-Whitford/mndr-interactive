/**
* WanderingNPC
* Author: Hayden Dalton
* Description: attach to NPC in club scene, it will wander around between the min and max
* distance set. It then waits the wait duration between moving to different locations.
* It then stops and looks at the player if they are close to the player, and then resume
* walking afterwards if the player moves out of range.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingNPC : MonoBehaviour
{
    public float minWanderDistance = 10f;
    public float maxWanderDistance = 15f;
    public float lookAtPlayer = 5f;
    public float waitDuration = 2f;
    private NavMeshAgent navMesh;
    private Transform target;
    private bool isPlayerInRange = false;
    private bool isWaiting = false;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        GoToNextPoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(target.position, transform.position);

        //Checks if player is close enough and then it stops and looks at player
        if (distanceToPlayer <= lookAtPlayer)
        {
            isPlayerInRange = true;
            LookAtPlayer();
        }
        //if the player leaves range then it starts moving again
        else if (isPlayerInRange && distanceToPlayer > lookAtPlayer)
        {
            isPlayerInRange = false;
            navMesh.isStopped = false;
            GoToNextPoint();
        }
        //extra check to go to new navPoint
        else if(!navMesh.pathPending && navMesh.remainingDistance < 0.5f)
        {
            StartCoroutine(WaitTime());
        }
    }

    //Code for stopping NPC and for it to look at player
    void LookAtPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        navMesh.isStopped = true;
    }

    //Move to random point
    void GoToNextPoint()
    {
        float randomWanderDistance = Random.Range(minWanderDistance, maxWanderDistance);

        Vector3 randomDirection = Random.insideUnitSphere * randomWanderDistance;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, randomWanderDistance, 1);
        Vector3 finalPosition = hit.position;
        navMesh.SetDestination(finalPosition);
        navMesh.isStopped = false;
    }

    //Wait time for NPC after it reaches its location
    IEnumerator WaitTime()
    {
        if (!isWaiting)
        {
            isWaiting = true;
            yield return new WaitForSeconds(waitDuration);
            GoToNextPoint();
            isWaiting = false;
        }
    }
}
