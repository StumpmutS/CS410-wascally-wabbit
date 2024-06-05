using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DeathController))]
public class RabbitDeath : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<DeathController>().OnDeath.AddListener(HandleDeath);
    }

    private void HandleDeath()
    {
        if (TryGetComponent<Spawner>(out var spawner)) spawner.Spawn();
        Destroy(gameObject);
    }
}