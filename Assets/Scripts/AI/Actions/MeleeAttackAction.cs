using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeAttackAction : Action
{
    public EnemyMeleeAttack enemyMeleeAttack;
    bool attacking = false;
    float timer = 0;
    float attackDuration = 1;

    private void Start()
    {
        interupting = false;
        canDoSimultaneously.Add(typeof(MovementAction));
    }

    public override void Execute()
    {
        if(!attacking)
        {
            timer = 0;
            enemyMeleeAttack.MeleeAttack();
            attacking = true;
        }
        
        if(attacking)
        {
            timer += Time.deltaTime;
            if(timer > attackDuration)
            {
                enemyMeleeAttack.EndAttack();
            }
            if(timer > expiryTime)
            {
                attacking = false;
            }
        }
    }
}
