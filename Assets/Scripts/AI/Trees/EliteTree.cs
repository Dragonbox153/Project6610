using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteTree : BaseTree
{
    void SetShouldEvade(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        GetComponent<ShouldEvadeDecision>().SetNodes(trueNode, falseNode);
    }
    void SetEvadeAttack(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        GetComponent<EvadeAttackDecision>().SetNodes(trueNode, falseNode);
    }
    private void Start()
    {
        SetShouldMove(new ActionNode(GetComponent<MovementAction>()), new ActionNode(GetComponent<PathFindAction>()));
        SetInRange(new ActionNode(GetComponent<FireAttackAction>()), GetComponent<ShouldMoveDecision>());
        SetEvadeAttack(new ActionNode(GetComponent<EvadeMeleeAction>()), new ActionNode(GetComponent<EvadeFireAction>()));
        SetShouldEvade(GetComponent<EvadeAttackDecision>(), GetComponent<InRangeDecision>());

        SetRootNode(GetComponent<ShouldEvadeDecision>());
        CallRepeating();
    }
}