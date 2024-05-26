using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Agent
{
    public UnityEvent JumpEvent;
    [field : SerializeField] public InputReader PlayerInput { get; private set; }
    #region Component Regeion
    public WeaponHolder WeaponCompo { get; private set; }
    #endregion
    private bool _canDoubleJump;
    protected override void Awake()
    {
        base.Awake();
        MovementCompo = GetComponent<AgentMovement>();
        WeaponCompo = transform.Find("WeaponHolder").GetComponent<WeaponHolder>();
        WeaponCompo.Innitialize(this);

        PlayerInput.JumpKeyEvent += HandleJumpKeyEvent;
    }
    private void Update()
    {
        MovementCompo.SetMovement(PlayerInput.Movement.x);
        HandleSpriteFlip(PlayerInput.MousePosition);
    }
    private void OnDestroy()
    {
        PlayerInput.JumpKeyEvent -= HandleJumpKeyEvent;
    }
    private void HandleJumpKeyEvent()
    {
        if (MovementCompo.isGround.Value)
        {
            _canDoubleJump = true;
            JumpProcess();
        }
        else if(_canDoubleJump)
        {
            _canDoubleJump= false;
            JumpEvent?.Invoke();
            MovementCompo.Jump();
        }

    }

    private void JumpProcess()
    {
        JumpEvent?.Invoke();
        MovementCompo.Jump();
    }

    public override void SetDeadState()
    {
        throw new NotImplementedException();
    }
    // #region Flip Character
    // public bool IsFacingRight()
    // {
    //     return Mathf.Approximately(transform.eulerAngles.y,0);

    // }
    // public void HandleSpriteFlip(Vector3 targerPosition)
    // {
    //     if(targerPosition.x < transform.position.x)
    //     {
    //         transform.eulerAngles = new Vector3(0, -180f, 0);
    //     }else if (targerPosition.x > transform.position.x)
    //     {
    //         transform.eulerAngles = Vector3.zero;
    //     }
    // }
    // #endregion
}
