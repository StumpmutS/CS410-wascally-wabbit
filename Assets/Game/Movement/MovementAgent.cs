using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MovementAgent : MonoBehaviour
{
    [SerializeField] private float destinationReachOffset = .1f;
    [SerializeField] private NavMeshAgent agent;

    private bool _pathSet;
    private bool hasBeenShot = false;
    private bool canBeShot = true;
    public float timePause = 5;
    public float pauseReset = 5;
    
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
        if (hasBeenShot)
        {
            timePause -= Time.deltaTime;
            if (timePause <= 0)
            {
                timePause = 5;
                agent.speed = 5;
                hasBeenShot = false;
                canBeShot = false;
            }
        }
        if (canBeShot == false)
        {
            pauseReset -= Time.deltaTime;
            if (pauseReset <= 0)
            {
                pauseReset = 5;
                canBeShot = true;
            }
        }
        
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (canBeShot == true)// && pauseReset > 0)
            {
                agent.speed = 0;
                hasBeenShot = true;
            }
        }
    }
}