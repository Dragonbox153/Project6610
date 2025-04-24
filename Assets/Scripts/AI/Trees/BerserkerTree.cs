using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerTree : BaseTree
{
    void SetShouldRush(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        GetComponent<ShouldRushDecision>().SetNodes(trueNode, falseNode);
    }

    private void Start()
    {

        SetShouldMove(new ActionNode(GetComponent<MovementAction>()), new ActionNode(GetComponent<PathFindAction>()));
        SetInRange(new ActionNode(GetComponent<FireAttackAction>()), GetComponent<ShouldMoveDecision>());
        SetShouldRush(new ActionNode(GetComponent<BerserkAction>()), GetComponent<InRangeDecision>());

        SetRootNode(GetComponent<ShouldRushDecision>());
        CallRepeating();
    }

}
