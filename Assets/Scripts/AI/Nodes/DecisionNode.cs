using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionNode : DecisionTreeNode
{
    DecisionTreeNode trueNode;
    DecisionTreeNode falseNode;

    public virtual bool IsTrue()
    {
        return false;
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
