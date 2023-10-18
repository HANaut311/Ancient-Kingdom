using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringerIdle : EnemyState
{   
    private Enemy_DeathBringer enemy;
    private Transform player;

    public DeathBringerIdle(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_DeathBringer _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
        player = PlayerManager.instance.player.transform;
    }

    public override void Update()
    {
        base.Update();

        if(!enemy.bossFightBegun)
            enemy.stats.MakeInvincible(true);
        else
            enemy.stats.MakeInvincible(false);

        if(Vector2.Distance(player.transform.position, enemy.transform.position) < 7)
            enemy.bossFightBegun = true;

        if(stateTimer < 0 && enemy.bossFightBegun)
            stateMachine.ChangeState(enemy.battleState);

    }

    public override void Exit()
    {
        base.Exit();


    }    
}
