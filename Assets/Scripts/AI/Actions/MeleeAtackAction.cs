using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeAtackAction : Action
{
    public EnemyMeleeAttack enemyMeleeAttack;

    private void Start()
    {
        interupting = false;
        canDoSimultaneously.Add(typeof(MovementAction));
    }

    public override void Execute()
    {
        enemyMeleeAttack.MeleeAttack();
    }
}
