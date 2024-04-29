using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MovementAgent : MonoBehaviour
{
    [SerializeField] private float destinationReachOffset = .1f;
    [SerializeField] private NavMeshAgent agent;

    private bool _pathSet;
    
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
        if (!agent.enabled) return;
        if (agent.pathPending) return;
        if (agent.hasPath) _pathSet = true;
        if (!_pathSet) return;
        if (agent.remainingDistance >= destinationReachOffset) return;
        FinishPath();
    }

    private void FinishPath()
    {
        agent.ResetPath();
        _pathSet = false;
        OnDestinationReached.Invoke(this);
    }
}