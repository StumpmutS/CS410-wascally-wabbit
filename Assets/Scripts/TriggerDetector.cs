using System;
using UnityEngine;
using UnityEngine.Events;
using Utility;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;

    public UnityEvent OnTargetHit = new();
    
    void OnTriggerEnter(Collider other)
    {
        if (LayerHelper.LayerEqualsMask(other.gameObject.layer, targetLayer))
        {
            OnTargetHit.Invoke();
        }
    }
}