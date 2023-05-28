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

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;
        agent.SetDestination(endLocation.transform.position);

        Worker.Embark += MoveTo;
    }

    private void MoveTo(Location location)
    {
        if (location == Location.Lab)
        {
            agent.SetDestination(startLocation.transform.position);
        }
        else
        {
            agent.SetDestination(endLocation.transform.position);
        }
    }
    
    void Update()
    {
        if (agent.velocity != Vector3.zero)
            animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}
