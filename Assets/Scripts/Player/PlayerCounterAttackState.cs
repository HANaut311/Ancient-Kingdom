
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{   
    private bool canCreateClone;

    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        canCreateClone = true;
        stateTimer = player.counterAttackDuration;
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Update()
    {
        base.Update();

        player.SetZeroVelocity();
    
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach(var hit in colliders)
        {   
            if(hit.GetComponent<ArrowController>() != null)
            {
                hit.GetComponent<ArrowController>().FlipArrow();
                SuccesfulCounterAttack();
            }

            if(hit.GetComponent<Enemy>() != null)
            {
                if(hit.GetComponent<Enemy>().CanBeStun())
                    {
                        SuccesfulCounterAttack();

                        player.skill.parry.UseSkill(); //restore health on parry

                        if (canCreateClone)
                        {
                            canCreateClone = false;
                            player.skill.parry.MakeMirageOnParry(hit.transform);
                        }

                    }
                }
        }  

        if(stateTimer < 0 || triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }

    private void SuccesfulCounterAttack()
    {
        stateTimer = 10;
        player.anim.SetBool("SuccessfulCounterAttack", true);
    }


    public override void Exit()
    {
        base.Exit();
    }
}
