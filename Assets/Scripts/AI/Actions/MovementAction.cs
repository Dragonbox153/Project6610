using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementAction : Action
{
    public EnemyMovement enemyMovement;
    public float distanceThreshold;
    public Node nextNode;

    private bool amIMoving = false;

    private void Start()
    {
        interupting = false;
        canDoSimultaneously.Add(typeof(MeleeAttackAction));
        canDoSimultaneously.Add(typeof(FireAttackAction));
    }

    public bool AmIMovingNow()
    {
        return amIMoving;
    }

    public void SetMovementFalse()
    {
        amIMoving = false;
    }

    public override void Execute()
    {
        nextNode = GetComponent<PathFindAction>().nextNode;

        if(Vector2.Distance(transform.position, nextNode.position) > distanceThreshold)
        {
            amIMoving = true;
            GameObject enemy = enemyMovement.gameObject;
            enemyMovement.acceleration = new Vector2(nextNode.position.x - enemy.transform.position.x, nextNode.position.y - enemy.transform.position.y).normalized;
            enemyMovement.acceleration *= enemyMovement.speed;
        }
        else
        {
            GetComponent<PathFindAction>().finishPath();
            enemyMovement.acceleration = Vector2.zero;
            amIMoving = false;
        }
        
    }
}
