using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionNode : DecisionTreeNode
{
    DecisionTreeNode trueNode;
    DecisionTreeNode falseNode;

    protected Func<bool> trueCheck;

    public virtual bool IsTrue()
    {
        return trueCheck();
    }

    public void SetNodes(DecisionTreeNode i_trueNode, DecisionTreeNode i_falseNode)
    {
        trueNode = i_trueNode;
        falseNode = i_falseNode;
    }

    protected DecisionTreeNode GetBranch()
    {
        return IsTrue() ? trueNode: falseNode;
    }

    public override ActionNode MakeDecision()
    {
        return this.GetBranch().MakeDecision();
    }
}
