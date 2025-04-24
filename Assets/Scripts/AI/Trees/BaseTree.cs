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
        shouldPathfind = new DecisionNode(() => {
            return GetComponent<PathFindAction>().DidIFindPath();
        },
        trueNode, falseNode);
    }

    protected void SetShouldMove(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        shouldMove = new DecisionNode(() => {
            Vector2 playerPoint = GameObject.Find("Player").transform.position;
            Vector2 myPoint = gameObject.transform.position;
            return (GetComponent<MovementAction>().AmIMovingNow() && Math.Abs((myPoint - playerPoint).magnitude) < 5.5);
        },
        trueNode, falseNode);
    }

    protected void SetInRange(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        inRange = new DecisionNode(() => {
            if (player != null)
            {
                Vector2 playerPoint = player.transform.position;
                Vector2 myPoint = gameObject.transform.position;
                Debug.Log(Math.Abs((myPoint - playerPoint).magnitude));
                // Is the enemy close?
                if (Math.Abs((myPoint - playerPoint).magnitude) < 1.7)
                {
                    return true;
                } 
            }
            return false;
        },
        trueNode, falseNode);
    }

    protected void SetShouldStand(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
    {
        shouldStand = new DecisionNode(() =>
        {
            if (player == null)
            {
                return true;
            }
            return false;
        }, trueNode, falseNode);
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
