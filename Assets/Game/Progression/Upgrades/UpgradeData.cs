using System;
using UnityEngine;

[Serializable]
public class UpgradeData
{
    [SerializeField] private string name;
    public string Name => name;
    [SerializeField] private UpgradeSO upgrade;
    public UpgradeSO Upgrade => upgrade;
}