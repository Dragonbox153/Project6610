using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldEvadeDecision : DecisionNode
{

    private void Awake()
    {
        trueCheck = (() =>
        {
            return gameObject.GetComponent<EnemyHealth>().isDamaged;
        });
    }
}
