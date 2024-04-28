using UnityEngine;

[CreateAssetMenu(menuName = "StateSystem/Decisions/HasTarget")]
public class HasTargetDecision : DecisionSO
{
    protected override bool Decide(StateMemory memory)
    {
        return memory.TryGetOrFindByType(this, out ITargetFinder targetFinder) && targetFinder.Target != null;
    }
}