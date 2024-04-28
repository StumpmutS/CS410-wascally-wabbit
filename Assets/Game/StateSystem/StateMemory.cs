using System.Collections.Generic;
using UnityEngine;

public class StateMemory : MonoBehaviour
{
    private Dictionary<StateSO, Dictionary<object, object>> _memory = new();

    public Dictionary<object, object> RetrieveMemory(StateSO state)
    {
        return _memory[state];
    }
}