using UnityEngine;

[CreateAssetMenu(menuName = "StateSystem/Transition")]
public class TransitionSO : ScriptableObject
{
    [SerializeField] private TransitionData data;
    public TransitionData Data => data;
}