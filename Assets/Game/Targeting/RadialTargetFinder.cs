using System.Collections;
using UnityEngine;

public class RadialTargetFinder : MonoBehaviour, ITargetFinder
{
    [SerializeField, Tooltip("In Seconds")] private float updateInterval = 1f;
    [SerializeField] private float searchRadius;
    [SerializeField] private LayerMask targetLayer;
    
    public Transform Target { get; private set; }

    private void Start()
    {
        StartCoroutine(CoSearch());
    }

    private IEnumerator CoSearch()
    {
        Search();
        yield return new WaitForSeconds(updateInterval);
        StartCoroutine(CoSearch());
    }

    private static readonly Collider[] Colliders = new Collider[128];
    private void Search()
    {
        var found = Physics.OverlapSphereNonAlloc(transform.position, searchRadius, Colliders, targetLayer);

        Transform target = null;
        var currentDistance = float.MaxValue;
        
        for (int i = 0; i < found; i++)
        {
            var distanceSquared = (Colliders[i].transform.position - transform.position).sqrMagnitude;
            if (distanceSquared > currentDistance) return;

            currentDistance = distanceSquared;
            target = Colliders[i].transform;
        }

        Target = target;
    }
}