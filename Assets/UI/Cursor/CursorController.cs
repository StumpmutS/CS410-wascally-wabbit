using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private CursorLockMode lockMode;
    [SerializeField] private bool visible;
    
    private void Start()
    {
        Cursor.lockState = lockMode;
        Cursor.visible = visible;
    }
}