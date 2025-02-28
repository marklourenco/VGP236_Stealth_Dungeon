using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIAgentRandom : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float wanderRadius = 10f;
    public float wanderTimer = 10f;

    private float timeSinceLastWander = 0f;

    void Start()
    {
        SetRandomDestination();
    }

    void Update()
    {
        timeSinceLastWander += Time.deltaTime;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance || timeSinceLastWander >= wanderTimer)
        {
            SetRandomDestination();
            timeSinceLastWander = 0f;
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;

        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
        }
    }
}