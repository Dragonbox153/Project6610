using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : Action
{
    EnemyMovement enemyMovement;
    public Vector2 targetPosition;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public override void Execute()
    {
        GameObject enemy = enemyMovement.gameObject;
        enemyMovement.acceleration = new Vector2(targetPosition.x - enemy.transform.position.x, targetPosition.y - enemy.transform.position.y).normalized;
        enemyMovement.acceleration *= enemyMovement.speed;
    }
}
