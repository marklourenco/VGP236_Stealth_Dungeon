using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform chaseTarget;

    public List<Transform> waypoints;
    private int currentWaypoint = 0;

    private AIState aiState;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        aiState = AIState.Patrol;
    }

    void Update()
    {
        if (aiState == AIState.Patrol)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
                navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
            }
        }
        if (aiState == AIState.Chase)
        {
            navMeshAgent.SetDestination(chaseTarget.position);
            if (Vector3.Distance(transform.position, chaseTarget.position) > 15)
            {
                aiState = AIState.Patrol;
                navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
            }
        }
    }

    public void HostileSpotted(Transform hostileTarget)
    {
        chaseTarget = hostileTarget;
        navMeshAgent.SetDestination(chaseTarget.position);
        aiState = AIState.Chase;
    }
}

public enum AIState
{
    Patrol,
    Chase
}