using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerTree : BaseTree
{
    protected DecisionNode shouldRush;

    void SetShouldRush(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        shouldRush = new DecisionNode(() => {
            return GetComponent<EnemyHealth>().health <= GetComponent<EnemyHealth>().maxHealth / 2;
        },
        trueNode, falseNode);
    }

    private void Awake()
    {
        SetShouldPathFind(new ActionNode(GetComponent<PathFindAction>()), new ActionNode(GetComponent<StandAction>()));
        SetInRange(new ActionNode(GetComponent<FireAttackAction>()), shouldPathfind);
        SetShouldMove(new ActionNode(GetComponent<MovementAction>()), inRange);
        SetShouldStand(new ActionNode(GetComponent<StandAction>()), new ActionNode(GetComponent<StandAction>()));
        SetShouldRush(shouldStand , shouldMove);

        SetRootNode(shouldRush);
        CallRepeating();
    }

}
