using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempActionTester : MonoBehaviour
{
    ActionManager act;

    void Start()
    {
        act = gameObject.GetComponent<ActionManager>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            act.Schedule(new MeleeAttackAction());
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            act.Schedule(new MovementAction());
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            act.Schedule(new FireAttackAction());
        }
    }
}
