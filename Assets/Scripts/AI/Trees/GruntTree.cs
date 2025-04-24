using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntTree : BaseTree
{
    void SetShouldFlee(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        GetComponent<ShouldFleeDecision>().SetNodes(trueNode, falseNode);
    }

    void SetInMeleeRange(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        GetComponent<InMeleeRangeDecision>().SetNodes(trueNode, falseNode);
    }

    private void Start()
    {
        SetShouldMove(new ActionNode(GetComponent<MovementAction>()), new ActionNode(GetComponent<PathFindAction>()));
        SetInRange(new ActionNode(GetComponent<FireAttackAction>()), GetComponent<ShouldMoveDecision>());
        SetInMeleeRange(new ActionNode(GetComponent<MeleeAttackAction>()), GetComponent<InRangeDecision>());
        SetShouldFlee(new ActionNode(GetComponent<FleeAction>()), GetComponent<InMeleeRangeDecision>());

        SetRootNode(GetComponent<ShouldFleeDecision>());
        CallRepeating();
    }
}
