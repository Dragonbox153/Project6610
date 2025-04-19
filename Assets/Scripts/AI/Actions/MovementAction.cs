using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : Action
{
    public EnemyMovement enemyMovement;
    public Vector2 targetPosition;

    private void Start()
    {
        interupting = false;
        canDoSimultaneously.Add(typeof(MeleeAtackAction));
    }

    public override void Execute()
    {
        GameObject enemy = enemyMovement.gameObject;
        enemyMovement.acceleration = new Vector2(targetPosition.x - enemy.transform.position.x, targetPosition.y - enemy.transform.position.y).normalized;
        enemyMovement.acceleration *= enemyMovement.speed;
    }
}
