using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : Action
{
    public EnemyMovement enemyMovement;
    public float distanceThreshold;
    public Vector2 targetPosition;

    private void Start()
    {
        interupting = false;
        canDoSimultaneously.Add(typeof(MeleeAttackAction));
    }

    public override void Execute()
    {
        if(Vector2.Distance(enemyMovement.gameObject.transform.position, targetPosition) > distanceThreshold)
        {
            GameObject enemy = enemyMovement.gameObject;
            enemyMovement.acceleration = new Vector2(targetPosition.x - enemy.transform.position.x, targetPosition.y - enemy.transform.position.y).normalized;
            enemyMovement.acceleration *= enemyMovement.speed;
        }
        else
        {
            enemyMovement.acceleration = Vector2.zero;
        }
        
    }
}
