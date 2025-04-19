using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : DecisionTreeNode
{
    Action action;

    public ActionNode(Action action)
    {
        this.action = action;
    }

    public override ActionNode MakeDecision()
    {
        return this;
    }

    public Action GetAction()
    {
        return action;
    }
}
