using UnityEngine;

public class UpgradeInitializer : MonoBehaviour
{
    [SerializeField] private bool reset;
    
    private void Start()
    {
        if (reset) UpgradeManager.Instance.Reset();
            
        UpgradeManager.Instance.Activate();
    }
}