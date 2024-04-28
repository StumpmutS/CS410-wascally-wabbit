using UnityEngine;

public abstract class DecisionSO : ScriptableObject
{
    [SerializeField] private bool checkTrue = true;

    public bool Test(StateMemory memory)
    {
        return checkTrue == Decide(memory);
    }
    
    protected abstract bool Decide(StateMemory memory);
}