using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected Enemy _enemy;
    protected EnemyStateMachine _stateMachine;

    protected int _animBoolHash;
    protected bool _endTriggerCalled;
    public virtual void Enter(){
        _enemy.AnimatorCompo.SetBool(_animBoolHash, true);
    }
    public virtual void UpdateState(){
        
    }
    public virtual void Exit(){
        _enemy.AnimatorCompo.SetBool(_animBoolHash, false);
    }
    public void AniamationEndTrigger(){
        _endTriggerCalled = true;
    }
    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName){
        _enemy = enemy;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);
    }
}
