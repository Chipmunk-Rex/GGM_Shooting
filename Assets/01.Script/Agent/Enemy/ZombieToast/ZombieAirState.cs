using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAirState : EnemyState
{
    public ZombieAirState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
}
