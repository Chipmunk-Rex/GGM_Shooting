using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChaseState : EnemyState
{
    public ZombieChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        float distance = Vector2.Distance(_enemy.targetTrm.position, _enemy.transform.position);
        if(distance > _enemy.detectRadius + 3){
            _stateMachine.ChangeState(ZomebieEnum.Idle);
            return;
        }
        _enemy.MovementCompo.SetMovement(Mathf.Clamp(_enemy.targetTrm.position.x - _enemy.transform.position.x, -1, 1));
        if(distance < _enemy.attackRadius && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time){
            _stateMachine.ChangeState(ZomebieEnum.Attack);
            return;
        }
    }
}
