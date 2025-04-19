using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionNode : DecisionTreeNode
{
    DecisionTreeNode trueNode;
    DecisionTreeNode falseNode;

    Func<bool> trueCheck;

    public DecisionNode(Func<bool> boolCheck)
    {
        trueCheck = boolCheck;
    }

    public virtual bool IsTrue()
    {
        return trueCheck();
    }

    protected DecisionTreeNode GetBranch()
    {
        return IsTrue() ? trueNode: falseNode;
    }

    public override DecisionTreeNode MakeDecision()
    {
        return this.GetBranch().MakeDecision();
    }
}
