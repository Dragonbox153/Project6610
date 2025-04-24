using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTree : MonoBehaviour
{
    // Start is called before the first frame update
    DecisionNode rootNode;
    protected DecisionNode shouldPathfind;
    protected DecisionNode shouldMove;
    protected DecisionNode inRange;
    protected DecisionNode shouldStand;
    protected GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    protected void SetShouldPathFind(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        GetComponent<ShouldPathfindDecision>().SetNodes(trueNode, falseNode);
    }

    protected void SetShouldMove(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        GetComponent<ShouldMoveDecision>().SetNodes(trueNode, falseNode);
    }

    protected void SetInRange(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        GetComponent<InRangeDecision>().SetNodes(trueNode, falseNode);
    }

    protected void SetRootNode(DecisionNode i_rootNode)
    {
        rootNode = i_rootNode;
    }


    protected void CallRepeating()
    {
        InvokeRepeating("performAct", 1, 0.1f);
    }

    void performAct()
    {
        GetComponent<ActionManager>().Schedule(rootNode.MakeDecision().GetAction());
    }
}
