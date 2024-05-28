using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Utility.Scripts;

public class UpgradeManager : Singleton<UpgradeManager>
{
    [SerializeField] private List<ListWrapper<UpgradeData>> _availableUpgrades;
    public List<ListWrapper<UpgradeData>> AvailableUpgrades => _availableUpgrades;
    
    private List<UpgradeSO> _selectedUpgrades = new(); // Order matters, don't change to HashSet
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void Activate()
    {
        foreach (var upgrade in _selectedUpgrades)
        {
            upgrade.Activate();
        }
    }

    public void AddUpgrade(UpgradeSO upgrade)
    { 
        // Again, don't change to HashSet, this is not a hot path
        if (!_selectedUpgrades.Contains(upgrade)) _selectedUpgrades.Add(upgrade); 
    }
}