using System;
using UnityEngine;

[Serializable]
public class TransitionData
{
    [SerializeField] private StateSO from;
    public StateSO From => from;
    [SerializeField] private StateSO to;
    public StateSO To => to;
    [SerializeField] private DecisionSO decision;
    public DecisionSO Decision => decision;
}