using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateSystem/Components/TargetedFlee")]
public class TargetedFleeStateComponent : StateComponentSO
{
    private HashSet<Type> _memorizedComponentTypes = new() { typeof(ITargetFinder), typeof(MovementAgent) };
    protected override HashSet<Type> MemorizedComponentTypes => _memorizedComponentTypes;

    public override void Tick(StateSO state, StateMemory memory)
    {
        var retrieved = memory.RetrieveMemory(state);
        if (!retrieved.TryGetFromType(out ITargetFinder targetFinder) || 
            !retrieved.TryGetFromType(out MovementAgent agent)) return;

        if (targetFinder.Target == null) agent.ClearDestination();
        else Flee(agent, targetFinder.Target);
    }

    private void Flee(MovementAgent agent, Transform target)
    {
        var direction = agent.transform.position - target.position;
        agent.SetDestination(agent.transform.position + direction.normalized * 20);
    }
}