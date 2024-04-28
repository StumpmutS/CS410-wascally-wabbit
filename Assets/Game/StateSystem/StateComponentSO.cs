using UnityEngine;

public abstract class StateComponentSO : ScriptableObject
{
    public virtual void Enter(StateMemory memory) { }
    
    public virtual void Tick(StateMemory memory) { }
    
    public virtual void Exit(StateMemory memory) { }
}