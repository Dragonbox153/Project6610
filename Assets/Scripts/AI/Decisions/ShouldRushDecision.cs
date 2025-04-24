using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldRushDecision : DecisionNode
{
    void Awake()
    {
        trueCheck = (() => 
        { 
            return GetComponent<EnemyHealth>().health <= GetComponent<EnemyHealth>().maxHealth / 2;
        });
    }
}
