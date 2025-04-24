using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeAttackDecision : DecisionNode
{
    protected GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        trueCheck = (() =>
        {
            if (player != null)
            {
                // Is the enemy close?
                if (Vector2.Distance(player.transform.position, transform.position) < 1.7)
                {
                    return true;
                }
            }
            return false;
        });
    }
}
