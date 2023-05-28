using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/** 
 * NavMovementController
 * 
 * A Unity class that uses the NavMeshAgent system to patrol between two points.
 * Animation is adjusted by the NavMeshAgent "Velocity" value against the Animator "Speed" parameter.
 * 
 * Example Usage:
 * 1. Attach this script to the GameObject with a NavMeshAgent and Animator component.
 * 2. Provide a reference to the start and end destination GameObjects in the inspector.
 * 3. Adjust speed value in inspector if a different movement speed is required.
**/

public class NavMovementController : MonoBehaviour
{
    public GameObject startLocation;
    public GameObject endLocation;
    public float speed = 3.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private workerState currentState;
    private enum workerState { Fetching, Returning };

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;
        agent.SetDestination(endLocation.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // NavAgent handling

        // Is agent not currently pathing and is within stopping distance
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
		{
            // Does agent not have a path set or has stopped moving
            if(!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
			{
				switch (currentState)
				{
                    case workerState.Fetching:
                        agent.SetDestination(startLocation.transform.position);
                        currentState = workerState.Returning;
                        break;

                    case workerState.Returning:
                        agent.SetDestination(endLocation.transform.position);
                        currentState = workerState.Fetching;
                        break;

                    default:
                        break;
				}
			}
		}

        // Animation handling

        if (agent.velocity != Vector3.zero)
            animator.SetFloat("Speed", agent.velocity.sqrMagnitude);       

    }
}
