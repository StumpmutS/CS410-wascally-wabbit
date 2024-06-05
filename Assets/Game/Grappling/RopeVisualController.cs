using UnityEngine;

public class RopeVisualController : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private Transform _origin;

    public void SetOrigin(Transform origin)
    {
        _origin = origin;
    }
    
    private void Update()
    {
        var dir = target.position - _origin.position;
        var halfLength = dir.magnitude / 2;

        // Assumes visuals should be scaling in y direction
        transform.position = _origin.position + dir.normalized * halfLength;
        transform.up = dir;
        transform.localScale = new Vector3(transform.localScale.x, halfLength, transform.localScale.z);
    }
}