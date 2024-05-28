using UnityEngine;
using Utility;

[CreateAssetMenu(menuName = "Upgrades/StatMod")]
public class StatModificationUpgradeSO : UpgradeSO
{
    [SerializeField] private SerializableDictionary<EStatType, float> stats;
    
    public override void Activate()
    {
        if (!PlayerReference.Instance.Player.TryGetComponent<StatManager>(out var statManager)) return;

        foreach (var statKvp in stats)
        {
            statManager.SetStat(statKvp.Key, statKvp.Value);
        }
    }
}