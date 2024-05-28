using UnityEngine;

public class UpgradeInitializer : MonoBehaviour
{
    private void Start()
    {
        UpgradeManager.Instance.Activate();
    }
}