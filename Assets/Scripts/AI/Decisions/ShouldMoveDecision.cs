using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldMoveDecision : DecisionNode
{
    private void Awake()
    {
        trueCheck = (() => {
            MovementAction movement = GetComponent<MovementAction>();
            return movement.nextNode != null && Vector2.Distance(transform.position, movement.nextNode.position) > movement.distanceThreshold;
        });
    }
}
