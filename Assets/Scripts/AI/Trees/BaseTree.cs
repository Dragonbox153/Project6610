using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTree : MonoBehaviour
{
    // Start is called before the first frame update
    DecisionNode rootNode;
    void Awake()
    {
        // If I found a path, move to it. Otherwise, find one.
        DecisionNode shouldPathfind = new DecisionNode(() => {
            return GetComponent<PathFindAction>().DidIFindPath();
        },
        new ActionNode(GetComponent<MovementAction>()), new ActionNode(GetComponent<PathFindAction>()));

        // Am I moving? If I am, shoot. Otherwise, move.
        DecisionNode shouldMove = new DecisionNode(() => {
            return GetComponent<MovementAction>().AmIMovingNow();
        },
        new ActionNode(GetComponent<FireAttackAction>()), shouldPathfind);


        // If enemy is far, shoot. If they are close, melee.
        DecisionNode inRange = new DecisionNode(() => {
            Vector2 playerPoint = GameObject.Find("Player").transform.position;
            Vector2 myPoint = gameObject.transform.position;
            Debug.Log(Math.Abs((myPoint-playerPoint).magnitude));
            // Is the enemy close?
            if(Math.Abs((myPoint-playerPoint).magnitude) < 1.7)
            {
                return true;
            }
            return false;
        },
        new ActionNode(GetComponent<MeleeAttackAction>()), shouldMove);


        rootNode = inRange;

        InvokeRepeating("performAct", 1, 1);
    }

    void performAct()
    {
        GetComponent<ActionManager>().Schedule(rootNode.MakeDecision().GetAction());
    }
}
