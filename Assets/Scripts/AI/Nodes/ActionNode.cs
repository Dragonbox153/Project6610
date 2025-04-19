using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : DecisionTreeNode
{
    Action action;

    public override DecisionTreeNode MakeDecision()
    {
        return this;
    }
}
