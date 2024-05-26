using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ZomebieEnum{
    Air,
    Idle,
    Chase,
    Attack,
    Dead
}
public class ZombieToast : Enemy
{
    public EnemyStateMachine stateMachine;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
        //상태 추가
        stateMachine.AddState(ZomebieEnum.Idle, new ZombieIdleState(this, stateMachine, "Idle"));
        stateMachine.AddState(ZomebieEnum.Chase, new ZombieChaseState(this, stateMachine, "Chase"));
        stateMachine.AddState(ZomebieEnum.Air, new ZombieAirState(this, stateMachine, "Air"));
        stateMachine.AddState(ZomebieEnum.Attack, new ZombieAttackState(this, stateMachine, "Attack"));
        stateMachine.AddState(ZomebieEnum.Dead, new ZombieDeadState(this, stateMachine, "Dead"));
        //시작상태 설정 , 준비;
        stateMachine.Initailize(ZomebieEnum.Idle, this);

    }
    private void Update() {
        stateMachine.CurrentState.UpdateState();
        if(targetTrm != null && IsDead == false)
            HandleSpriteFlip(targetTrm.position);
    }
    public override void AniamationEndTrigger()
    {
        stateMachine.CurrentState.AniamationEndTrigger();
    }

    public override void SetDeadState()
    {
        stateMachine.ChangeState(ZomebieEnum.Dead);
    }
}
