using UnityEngine;
using UnityEngine.Events;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public UnityEvent OnTargetHit = new();
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            OnTargetHit.Invoke();
        }
    }
}
