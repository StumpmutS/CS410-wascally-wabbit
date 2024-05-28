using UnityEngine;
using UnityEngine.Events;
using Utility;

public class StatManager : MonoBehaviour
{
    [SerializeField] private SerializableDictionary<EStatType, float> stats;

    public UnityEvent<EStatType> OnStatChanged = new();

    public float GetStat(EStatType type)
    {
        return stats[type];
    }
    
    public void SetStat(EStatType type, float value)
    {
        stats[type] = value;
        OnStatChanged.Invoke(type);
    }
}