using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldPathfindDecision : DecisionNode
{
    void Awake()
    {
        trueCheck = (() =>
        {
            return !GetComponent<PathFindAction>().DidIFindPath();
        });
    }
}
