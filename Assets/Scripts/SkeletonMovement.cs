using UnityEngine;
using UnityEngine.AI;

public class SkeletonMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    void Update()
    {
        float speed = agent.velocity.magnitude;

        animator.SetFloat("Speed", speed);
    }
}
