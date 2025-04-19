using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [SerializeField] List<Action> pending = new List<Action>();
    [SerializeField] List<Action> active = new List<Action>();

    public void Schedule(Action action)
    {
        action.queuedTime = 0;
        pending.Add(action);
        pending.OrderBy(p => p.priority);
        pending = pending.Distinct().ToList();
    }

    void UpdateActionQueuedTime()
    {
        foreach (Action action in pending)
        {
            if (pending.Count > 0)
            {

                action.queuedTime += Time.deltaTime;
                if (action.queuedTime > action.expiryTime)
                {
                    pending.Remove(action);
                }
            }
        }

        foreach (Action action in active)
        {
            if (active.Count > 0)
            {

                action.queuedTime += Time.deltaTime;
                if (action.queuedTime > action.expiryTime)
                {
                    active.Remove(action);
                }
            }
        }
    }

    void CheckInterrupts()
    {
        if (active.Count > 0)
        {
            Action highestPriorityActive = active.Last();
            foreach (Action pendingAction in pending)
            {
                if (pendingAction.CanInterupt() || highestPriorityActive == null)
                {
                    active.Clear();
                    active.Add(pendingAction);
                    pending.Remove(pendingAction);
                }
            }
        }
        else if (pending.Count > 0)
        {
            active.Add(pending.Last());
            pending.Remove(pending.Last());
        }
    }

    void PromoteQueuedToActive()
    {
        if (active.Count > 0)
        {
            Action highestPriorityActive = active.Last();
            foreach (Action pendingAction in pending)
            {
                if (pendingAction.CanDoBoth(highestPriorityActive.GetType()))
                {
                    active.Add(pendingAction);
                }
            }
        }
        else if (pending.Count > 0)
        {
            active.Add(pending.Last());
            pending.Remove(pending.Last());
        }
    }

    void RunActiveActions()
    {
        foreach (Action action in active)
        {
            if (active.Count > 0)
            {
                action.Execute();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z)) {
            Schedule(GetComponent<MeleeAttackAction>());
        }

        if(Input.GetKeyUp(KeyCode.X))
        {
            GetComponent<MovementAction>().targetPosition = GameObject.Find("Player").transform.position;
            Schedule(GetComponent<MovementAction>());
        }

        active = active.Distinct().ToList();
        UpdateActionQueuedTime();
        CheckInterrupts();
        PromoteQueuedToActive();
        RunActiveActions();
    }
}
