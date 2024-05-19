using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Agent
{
    [Header("Attack Settings")]
    public float detectRadius;
    public float attackRadius;
    public float attackCooldown;
    // public LayerMask whatIsPlayer;
    public ContactFilter2D contactFilter;
    [HideInInspector] public Transform targetTrm = null;
    [HideInInspector] public float lastAttackTime;
    private int _enemyLayer;
    public bool CanStateChangeable{ get; private set; } = true;
    public Collider2D[] _colliders;
    protected override void Awake() {
        base.Awake();
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
    #endif
}
