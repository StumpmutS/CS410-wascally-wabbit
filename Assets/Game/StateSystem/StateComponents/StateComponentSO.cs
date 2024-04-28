using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateComponentSO : ScriptableObject
{
    private static HashSet<Type> _defaultHashset = new();
    protected virtual HashSet<Type> MemorizedComponentTypes => _defaultHashset;
    
    public virtual void Enter(StateSO state, StateMemory memory)
    {
        var retrieved = memory.RetrieveMemory(state);
        foreach (var type in MemorizedComponentTypes)
        {
            retrieved[type] = memory.GetComponent(type);
        }
    }
    
    public virtual void Tick(StateSO state, StateMemory memory) { }

    public virtual void Exit(StateSO state, StateMemory memory)
    {
        var retrieved = memory.RetrieveMemory(state);
        foreach (var type in MemorizedComponentTypes)
        {
            retrieved.Remove(type);
        }
    }
}