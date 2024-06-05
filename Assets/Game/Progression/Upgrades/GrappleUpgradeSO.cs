using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Grapple")]
public class GrappleUpgradeSO : UpgradeSO
{
    public override void Activate()
    {
        if (!PlayerReference.Instance.Player.TryGetComponent<Grappler>(out var grapple)) return;
        
        grapple.Activate();
    }
}