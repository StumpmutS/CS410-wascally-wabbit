using System.Collections.Generic;
using UnityEngine;

public static class MemoryHelpers
{
    public static bool TryGetFromType<T>(this Dictionary<object, object> dictionary, out T result)
    {
        result = default;
        if (!dictionary.TryGetValue(typeof(T), out var foundObject) || foundObject is not T found) return false;
        result = found;
        return true;
    }

    public static bool TryGetOrFindByType<T>(this StateMemory memory, object memoryId, out T result)
    {
        var retrieved = memory.RetrieveMemory(memoryId);
        if (retrieved.TryGetFromType(out result)) return true;

        result = memory.GetComponent<T>();
        retrieved[typeof(T)] = result;
        
        if (result != null) return true;
        Debug.LogWarning($"Could not find component of type \"{typeof(T)}\" on game object \"{memory.gameObject}\"");
        return false;
    }
}