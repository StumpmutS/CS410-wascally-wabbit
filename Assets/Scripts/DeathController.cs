using System;
using UnityEngine;
using UnityEngine.Events;

public class DeathController : MonoBehaviour
{
    public UnityEvent OnDeath = new();
    
    public void Die()
    {
        OnDeath.Invoke();
    }
}