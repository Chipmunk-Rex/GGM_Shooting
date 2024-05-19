using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : EnemyState
{
    private float _attackJumpPower = 3f;
    public ZombieAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.StopImmediately(false);
        Vector2 dir = _enemy.targetTrm.position - _enemy.transform.position;
        dir.y = _attackJumpPower;
        
        _enemy.MovementCompo.JumpTo(dir);
    }
    public override void UpdateState()
    {
        _enemy.lastAttackTime = Time.time;
        base.UpdateState();
        if(_endTriggerCalled){
            _endTriggerCalled = false;
            _stateMachine.ChangeState(ZomebieEnum.Chase);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
