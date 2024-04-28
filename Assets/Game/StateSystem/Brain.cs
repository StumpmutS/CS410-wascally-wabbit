using System.Collections.Generic;
using UnityEngine;
using Utility;

[RequireComponent(typeof(StateMemory))]
public class Brain : MonoBehaviour
{
    [SerializeField] private StateSO defaultState;
    [SerializeField] private List<TransitionData> transitions;
    [SerializeField] private List<TransitionData> anyTransitions;
    private StateSO _currentState;
    private StateMemory _memory;
    
    private void Awake()
    {
        _memory = this.AddOrGetComponent<StateMemory>();
        _currentState = defaultState;
        _currentState.Enter(_memory);
    }

    private void SetState(StateSO from, StateSO to)
    {
        if (_currentState.GetType() != from.GetType()) return;

        _currentState.Exit(_memory);
        _currentState = to;
        _currentState.Enter(_memory);
    }

    public void Tick()
    {
        _currentState.Tick(_memory);
        CheckTransitions();
    }

    private void CheckTransitions()
    {
        foreach (var transition in transitions)
        {
            if (!transition.Decision.Test()) continue;
            
            SetState(transition.From, transition.To);
            return;
        }

        foreach (var transition in anyTransitions)
        {
            if (!transition.Decision.Test()) continue;

            SetState(_currentState, transition.To);
            return;
        }
    }
}