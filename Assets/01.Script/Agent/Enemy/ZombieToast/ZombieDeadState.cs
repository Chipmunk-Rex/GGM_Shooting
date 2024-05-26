using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : EnemyState
{
    private readonly int _deadLayer = LayerMask.NameToLayer("DeadBody");
    private bool _onExplosion = false;
    public ZombieDeadState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.gameObject.layer = _deadLayer;
        _enemy.MovementCompo.StopImmediately();
        _enemy.SetDead(true);
        _onExplosion = false;
    }
    public override void UpdateState()
    {
        base.UpdateState();

        if(_endTriggerCalled && !_onExplosion){
            _onExplosion = true;
            PlayerExplosion();
        }
    }

    private void PlayerExplosion()
    {

        _enemy.FinalDeadEvent?.Invoke();
    //    EffectPlayer effectPlayer = PoolManager.Instance.Pop("ZombieExplosion") as EffectPlayer;
    //    effectPlayer.SetPositionAndPlay(_enemy.transform.position);

        IPoolable poolable = _enemy.GetComponent<IPoolable>();
        if(poolable != null)
            PoolManager.Instance.Push(poolable);
        else
            GameObject.Destroy(_enemy.gameObject);
        
    }
}
