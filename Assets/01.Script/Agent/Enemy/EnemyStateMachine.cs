using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentState{get; private set;}
    public Dictionary<ZomebieEnum, EnemyState> stateDictionary = new();
    public Enemy _enemy;
    public void Initailize(ZomebieEnum startState, Enemy enemy){
        _enemy = enemy;
        CurrentState = stateDictionary[startState];
        CurrentState.Enter();
    }
    public void ChangeState(ZomebieEnum newState, bool forceMode = true){
        if(_enemy.CanStateChangeable == false && forceMode == false) return;
            if(_enemy.CanStateChangeable == false && forceMode == false) return;
            if(_enemy.IsDead) return;

            CurrentState.Exit();
            CurrentState = stateDictionary[newState];
            CurrentState.Enter();
        
    }
    public void AddState(ZomebieEnum stateEnum, EnemyState enemyState) => stateDictionary.Add(stateEnum, enemyState);
}
