using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "StateSystem/Components/Patrol")]
public class PatrolStateComponent : StateComponentSO
{
    [SerializeField] private Vector3 patrolCenter;
    [SerializeField] private Vector3 patrolExtents;
    
    private HashSet<Type> _memorizedComponentTypes = new() { typeof(MovementAgent) };
    protected override HashSet<Type> MemorizedComponentTypes => _memorizedComponentTypes;

    protected override void HandleEnter(StateMemory memory)
    {
        var retrieved = memory.RetrieveMemory(this);
        if (!retrieved.TryGetFromType(out MovementAgent agent)) return;
        agent.OnDestinationReached.AddListener(NewDestination);
        NewDestination(agent);
    }

    private void NewDestination(MovementAgent agent)
    {
        agent.SetDestination(GenerateDestination());
    }

    private Vector3 GenerateDestination()
    {
        return patrolCenter + new Vector3(
            Random.Range(-patrolExtents.x, patrolExtents.x),
            Random.Range(-patrolExtents.y, patrolExtents.y),
            Random.Range(-patrolExtents.z, patrolExtents.z));
    }

    protected override void HandleExit(StateMemory memory)
    {
        var retrieved = memory.RetrieveMemory(this);
        if (!retrieved.TryGetFromType(out MovementAgent agent)) return;
        agent.OnDestinationReached.RemoveListener(NewDestination);
    }
}