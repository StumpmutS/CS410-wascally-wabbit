using UnityEngine;

[CreateAssetMenu(menuName = "StateSystem/Decisions/Always")]
public class AlwaysDecision : DecisionSO
{
    protected override bool Decide(StateMemory memory) => true;
}