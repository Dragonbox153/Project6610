using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttackAction : Action
{
    public EnemyFireBehavior enemyFireBehavior;
    bool attacking = false;
    float timer = 0;

    private void Start()
    {
        interupting = false;
        canDoSimultaneously.Add(typeof(MovementAction));
    }

    public override void Execute()
    {
        if (!attacking)
        {
            timer = 0;
            StartCoroutine(enemyFireBehavior.FireCoroutine(5));
            attacking = true;
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer > expiryTime)
            {
                attacking = false;
            }
        }
    }
}
