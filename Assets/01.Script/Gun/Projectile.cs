using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayper;
    protected bool _isDead = false;
    protected float _timer = 0;
    protected Rigidbody2D _rigidBody;

    protected virtual void Awake(){
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    public void ResetItem(){
        _isDead = false;
        _timer = 0;
    }
    public abstract void InitAndFire(Transform firePosTrm, int damage, float knockBackPower);

    
}
