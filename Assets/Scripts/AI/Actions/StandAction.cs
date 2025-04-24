using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandAction : Action
{
    public override void Execute()
    {
        GetComponent<EnemyMovement>().acceleration = Vector2.zero;
    }
}
