using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldRushDecision : DecisionNode
{
    void Awake()
    {
        trueCheck = (() => 
        { 
            List<BerserkerTree> berserkers = GameObject.FindObjectsByType<BerserkerTree>(FindObjectsSortMode.None).ToList();
            return GetComponent<EnemyHealth>().health <= GetComponent<EnemyHealth>().maxHealth / 2 || berserkers.Count() == 0;
        });
    }
}
