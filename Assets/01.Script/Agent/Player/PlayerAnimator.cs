using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private AgentMovement _movement;
    private Animator _animaoter;
    private readonly int _velocityHash = Animator.StringToHash("Velocity");
    private readonly int _isGroundHash = Animator.StringToHash("Isground");
    private void Awake()
    {
        _animaoter = GetComponent<Animator>();
        _movement.isGround.OnvalueChanged += HandleGroundChanged;
    }

    private void HandleGroundChanged(bool prev, bool next)
    {
        _animaoter.SetBool(_isGroundHash, next);
    }
    private void FixedUpdate()
    {
        float absVelocity = Mathf.Abs(_movement.rbCompo.velocity.x);
        _animaoter.SetFloat(_velocityHash,absVelocity);
    }
}
