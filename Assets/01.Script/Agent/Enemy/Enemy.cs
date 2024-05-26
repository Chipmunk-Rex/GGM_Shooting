using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : Agent
{
    public UnityEvent FinalDeadEvent;
    [Header("Attack Settings")]
    public float detectRadius;
    public float attackRadius;
    public float knockBackPower;
    int attackDamage;
    public float attackCooldown;
    // public LayerMask whatIsPlayer;
    public ContactFilter2D contactFilter;
    [HideInInspector] public Transform targetTrm = null;
    [HideInInspector] public float lastAttackTime;
    protected int _enemyLayer;
    public bool CanStateChangeable{ get; protected set; } = true;
    public Collider2D[] _colliders;
    public DamageCaster DamageCasterCompo{get;protected set;}
    protected override void Awake() {
        base.Awake();
        DamageCasterCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        _enemyLayer = LayerMask.NameToLayer("Enemy");
        _colliders = new Collider2D[1];
    }
    public Collider2D GetPlayerInRange(){
        int count = Physics2D.OverlapCircle(transform.position, detectRadius, contactFilter, _colliders);
        return count > 0 ? _colliders[0] : null;
    }
    public abstract void AniamationEndTrigger();
    #if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.white;
    }

    public void SetDead(bool value)
    {
        IsDead = true;
        CanStateChangeable = !value;
        FinalDeadEvent?.Invoke();
    }
    //적들마다 공격 방식이 다를 수 있으니 virtual로 만듬
    public virtual void Attack(){
        DamageCasterCompo.CastDamage(attackDamage, knockBackPower);
    }
#endif
}
