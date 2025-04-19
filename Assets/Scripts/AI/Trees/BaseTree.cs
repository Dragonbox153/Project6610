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
        DecisionNode inRange = new DecisionNode(() => {
            Vector2 playerPoint = GameObject.Find("Player").transform.position;
            Vector2 myPoint = gameObject.transform.position;
            Debug.Log(Math.Abs((myPoint-playerPoint).magnitude));
            if(Math.Abs((myPoint-playerPoint).magnitude) < 1.7)
            {
                return true;
            }
            return false;
        },
        new ActionNode(GetComponent<MeleeAttackAction>()), new ActionNode(GetComponent<FireAttackAction>()));

        rootNode = inRange;

        InvokeRepeating("performAct", 2, 2);
    }

    void performAct()
    {
        GetComponent<ActionManager>().Schedule(rootNode.MakeDecision().GetAction());
    }
}
