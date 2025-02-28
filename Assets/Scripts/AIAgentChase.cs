using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgentChase : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform chaseTarget;

    void Update()
    {
        navMeshAgent.SetDestination(chaseTarget.position);
    }
}