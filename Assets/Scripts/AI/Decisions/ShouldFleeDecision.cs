using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShouldFleeDecision : DecisionNode
{
    float timer = 0;
    private void Awake()
    {
        trueCheck = (() => {
            if(GetComponent<EnemyHealth>().health <= GetComponent<EnemyHealth>().maxHealth / 4)
            {
                timer += Time.deltaTime;
            }
            List<BerserkerTree> berserkers = GameObject.FindObjectsByType<BerserkerTree>(FindObjectsSortMode.None).ToList();
            return (GetComponent<EnemyHealth>().health <= GetComponent<EnemyHealth>().maxHealth / 4 && timer < 2) || berserkers.Count() == 0;
        });
    }
}
