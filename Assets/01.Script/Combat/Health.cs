using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnHitEvent;
    public UnityEvent OnDeadEvent;
    [SerializeField] private int _maxHealth = 150;
    private Agent _owner;
    private int _currentHealth;
    public void Initialize(Agent owner){
        _owner = owner;
        ResetHealth();
    }

    private void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int amount, Vector2 normal, Vector2 point, float knockbackPower){
        _currentHealth -= amount;
        OnHitEvent?.Invoke();
        if(_currentHealth <= 0){
            OnDeadEvent?.Invoke();
        }
    }
}
