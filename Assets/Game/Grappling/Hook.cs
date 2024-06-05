using System;
using System.Collections;
using UnityEngine;
using Utility;

public class Hook : MonoBehaviour
{
    [SerializeField] private float force = 500f;
    [SerializeField] private RopeVisualController ropeVisuals;

    private Rigidbody _rigidbody;
    private bool _ready;
    
    public event Action<Vector3> OnHooked = delegate { };
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Transform origin)
    {
        ropeVisuals.SetOrigin(origin);
    }

    private IEnumerator Start()
    {
        _rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
        
        // Because I don't want to make a fully fleshed out grappling system, as evidenced by the rest of the code
        yield return new WaitForSeconds(.01f);
        _ready = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_ready) return;
        
        this.RemoveOneComponent<Rigidbody>();
        var hookedPos = other.GetContact(0).point;
        transform.position = hookedPos;
        OnHooked.Invoke(hookedPos);
    }
}