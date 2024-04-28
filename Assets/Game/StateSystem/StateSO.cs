using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateSystem/State")]
public class StateSO : ScriptableObject
{
    [SerializeField] private List<StateComponentSO> components;

    public void Enter(StateMemory memory)
    {
        foreach (var component in components)
        {
            component.Enter(memory);
        }
    }
    
    public void Tick(StateMemory memory)
    {
        foreach (var component in components)
        {
            component.Tick(memory);
        }
    }
    
    public void Exit(StateMemory memory)
    {
        foreach (var component in components)
        {
            component.Exit(memory);
        }
    }
}