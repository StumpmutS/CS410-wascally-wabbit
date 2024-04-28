using UnityEngine;

[CreateAssetMenu(menuName = "StateSystem/Decisions/Always")]
public class AlwaysDecision : DecisionSO
{
    public override bool Test() => true;
}