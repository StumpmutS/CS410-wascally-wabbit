using System.Collections.Generic;
using UnityEngine;
using Utility;

[RequireComponent(typeof(StateMemory))]
public class Brain : MonoBehaviour
{
    [SerializeField] private StateSO defaultState;
    [SerializeField] private List<TransitionSO> transitions;
    [SerializeField] private List<TransitionSO> anyTransitions;
    
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

    private void Update()
    {
        _currentState.Tick(_memory);
        CheckTransitions();
    }

    private void CheckTransitions()
    {
        foreach (var transition in transitions)
        {
            if (!transition.Data.Decision.Test(_memory)) continue;
            
            SetState(transition.Data.From, transition.Data.To);
            return;
        }

        foreach (var transition in anyTransitions)
        {
            if (!transition.Data.Decision.Test(_memory)) continue;

            SetState(_currentState, transition.Data.To);
            return;
        }
    }
}