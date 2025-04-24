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
        canDoSimultaneously.Add(typeof(EvadeAction));
    }

    public override void Execute()
    {
        GetComponent<MovementAction>().SetMovementFalse();
        if (!attacking)
        {
            timer = 0;
            StartCoroutine(enemyFireBehavior.FireCoroutine(2));
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
