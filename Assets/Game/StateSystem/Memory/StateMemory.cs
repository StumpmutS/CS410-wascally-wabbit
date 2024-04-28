using System.Collections.Generic;
using UnityEngine;

public class StateMemory : MonoBehaviour
{
    private Dictionary<object, Dictionary<object, object>> _memory = new();

    public Dictionary<object, object> RetrieveMemory(object memoryId)
    {
        if (!_memory.TryGetValue(memoryId, out var memory))
        {
            _memory[memoryId] = new Dictionary<object, object>();
            memory = _memory[memoryId];
        }
        
        return memory;
    }

    public bool ClearMemory(object memoryId)
    {
        return _memory.Remove(memoryId);
    }
}