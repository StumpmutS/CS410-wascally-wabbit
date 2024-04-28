using UnityEngine;

[CreateAssetMenu(menuName = "StateSystem/Decisions/Never")]
public class NeverDecision : DecisionSO
{
    public override bool Test() => false;
}