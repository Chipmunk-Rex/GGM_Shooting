using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile, IPoolable
{
    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private float _lifeTime = 2f;

    private int _damage;
    private float _knockPower;
    private Vector2 _fireDirection;

    [SerializeField] private string _PoolName;
    public string PoolName => _PoolName; //Get 람다식 단축
    public GameObject ObjectPrefab => gameObject;

    public override void InitAndFire(Transform firePosTrm, int damage, float knockBackPower)
    {
        this._damage = damage;
        this._knockPower = knockBackPower;
        transform.SetPositionAndRotation(firePosTrm.position,firePosTrm.rotation);
        _fireDirection = firePosTrm.right;
    }
    private void FixedUpdate(){
        _rigidBody.velocity = _fireDirection * _moveSpeed;
        _timer += Time.deltaTime;
        if(_timer >= _lifeTime){
            DestroyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(_isDead) return;
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        _isDead = true;
        EffectPlayer effectPlayer = PoolManager.Instance.Pop("BulletImpact") as EffectPlayer;
        effectPlayer.SetPositionAndRotation(transform.position);
        PoolManager.Instance.Push(this);
    }
}
