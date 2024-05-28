using UnityEngine;

public class UpgradeUIController : MonoBehaviour
{
    [SerializeField] private LayoutDisplay layoutDisplay;
    [SerializeField] private CallbackToggle callbackTogglePrefab;

    private UpgradeSO _selected;
    
    private void Start()
    {
        Populate();
    }

    public void ConfirmSelection()
    {
        if (_selected != null) UpgradeManager.Instance.AddUpgrade(_selected);
    }

    private void Populate()
    {
        layoutDisplay.Clear();

        foreach (var upgrade in UpgradeManager.Instance.AvailableUpgrades[LevelManager.Instance.CurrentLevelIndex - 1].List)
        {
            layoutDisplay.AddPrefab(callbackTogglePrefab, t => InitToggle(t, upgrade));
        }
    }

    private void InitToggle(CallbackToggle toggle, UpgradeData data)
    {
        toggle.Init(new CallbackToggleData(OnToggled, data));
        if (!toggle.TryGetComponent<Label>(out var label)) return;
        
        label.SetLabel(data.Name);
    }

    private void OnToggled(object dataObject, bool value)
    {
        if (dataObject is not UpgradeData data) return;

        if (!value)
        {
            if (_selected == data.Upgrade) _selected = null;
            return;
        }
        
        _selected = data.Upgrade;
    }
}