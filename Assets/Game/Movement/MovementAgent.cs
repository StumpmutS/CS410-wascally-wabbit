using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MovementAgent : MonoBehaviour
{
    [SerializeField] private float destinationReachOffset = .1f;
    [SerializeField] private NavMeshAgent agent;

    public UnityEvent<MovementAgent> OnDestinationReached = new();
    
    public void SetDestination(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void ClearDestination()
    {
        agent.ResetPath();
    }

    private void Update()
    {
        if (!agent.hasPath || agent.pathPending) return;

        if ((agent.destination - transform.position).sqrMagnitude <= destinationReachOffset * destinationReachOffset)
        {
            OnDestinationReached.Invoke(this);
            agent.ResetPath();
        }
    }
}