using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateComponentSO : ScriptableObject
{
    private static HashSet<Type> _defaultHashset = new();
    protected virtual HashSet<Type> MemorizedComponentTypes => _defaultHashset;
    
    public void Enter(StateMemory memory)
    {
        // Store memorized components in memory
        var retrieved = memory.RetrieveMemory(this);
        foreach (var type in MemorizedComponentTypes)
        {
            retrieved[type] = memory.GetComponent(type);
        }
        
        HandleEnter(memory);
    }

    /// <summary>
    /// Called after memorized components are found
    /// </summary>
    protected virtual void HandleEnter(StateMemory memory) { }
    
    public virtual void Tick(StateMemory memory) { }

    public void Exit(StateMemory memory)
    {
        HandleExit(memory);
     
        // Clear memory
        var retrieved = memory.RetrieveMemory(this);
        foreach (var type in MemorizedComponentTypes)
        {
            retrieved.Remove(type);
        }
    }
    
    /// <summary>
    /// Called before memorized components are cleared
    /// </summary>
    protected virtual void HandleExit(StateMemory memory) { }
}