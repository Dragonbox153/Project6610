using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttackAction : Action
{
    public EnemyFireBehavior enemyFireBehavior;

    private void Start()
    {
        interupting = false;
        canDoSimultaneously.Add(typeof(MovementAction));
    }

    public override void Execute()
    {
        StartCoroutine(enemyFireBehavior.FireCoroutine(5));
    }
}
