using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZombieGroundState : EnemyState
{
    protected ZombieGroundState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.isGround.OnvalueChanged += HandleGroundChange;
        HandleGroundChange(false, _enemy.MovementCompo.isGround.Value);
    }
    public override void Exit()
    {
        _enemy.MovementCompo.isGround.OnvalueChanged -= HandleGroundChange;
        base.Exit();
    }
    private void HandleGroundChange(bool prv, bool next){
        if(next == false){
            _stateMachine.ChangeState(ZomebieEnum.Air);
        }
    }
}
