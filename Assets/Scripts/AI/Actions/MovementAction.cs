using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : Action
{
    public EnemyMovement enemyMovement;
    public float distanceThreshold;
    public List<Node> path;

    private void Start()
    {
        interupting = false;
        canDoSimultaneously.Add(typeof(MeleeAttackAction));
        canDoSimultaneously.Add(typeof(FireAttackAction));
    }

    public override void Execute()
    {
        path = GetComponent<PathFindAction>().path;

        if(Vector2.Distance(enemyMovement.gameObject.transform.position, path[0].position) > distanceThreshold)
        {
            GameObject enemy = enemyMovement.gameObject;
            enemyMovement.acceleration = new Vector2(path[0].position.x - enemy.transform.position.x, path[0].position.y - enemy.transform.position.y).normalized;
            enemyMovement.acceleration *= enemyMovement.speed;
        }
        else
        {
            GetComponent<PathFindAction>().path.Remove(path[0]);
            enemyMovement.acceleration = Vector2.zero;
        }
        
    }
}
