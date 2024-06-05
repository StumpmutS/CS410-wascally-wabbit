using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Grappler : MonoBehaviour
{
    [SerializeField] private Hook hookPrefab;
    [SerializeField] private Transform fireLocation;
    [SerializeField] private float grappleForce = 10f;
    
    private bool _active;
    private Hook _firedHook;
    private bool _latched;
    private Vector3 _latchPosition;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Activate()
    {
        _active = true;
    }

    private void Update()
    {
        if (!_active) return;

        if (Input.GetMouseButtonDown(1)) ToggleGrapple();
        
        if (Input.GetKey(KeyCode.Q)) TryGrapple();
    }

    private void ToggleGrapple()
    {
        if (_firedHook != null)
        {
            _latched = false;
            Destroy(_firedHook.gameObject);
            return;
        }
        
        _firedHook = Instantiate(hookPrefab, fireLocation.position, fireLocation.rotation);
        _firedHook.Init(fireLocation);
        _firedHook.OnHooked += HandleHooked;
    }

    private void HandleHooked(Vector3 position)
    {
        _latched = true;
        _latchPosition = position;
    }

    private void TryGrapple()
    {
        if (!_latched) return;
        
        _characterController.Move((_latchPosition - transform.position).normalized * grappleForce);
    }
}