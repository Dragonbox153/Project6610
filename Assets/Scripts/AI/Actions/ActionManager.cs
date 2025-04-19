using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    List<Action> pending;
    List<Action> active;

    public void Schedule(Action action)
    {
        pending.Add(action);
        pending.OrderBy(p => p.priority);
    }

    void UpdateActionQueuedTime()
    {
        foreach (Action action in pending)
        {
            action.queuedTime += Time.deltaTime;

            if(action.queuedTime > action.expiryTime )
            {
                pending.Remove(action);
            }
        }
    }

    void CheckInterrupts()
    {
        Action highestPriorityActive = active[pending.Count - 1];
        foreach (Action pendingAction in pending)
        {
            if (pendingAction.CanInterupt())
            {
                active.Clear();
                active.Add(pendingAction);
                pending.Remove(pendingAction);
            }
        }
    }

    void PromoteQueuedToActive()
    {
        Action highestPriorityActive = active[pending.Count - 1];
        foreach (Action pendingAction in pending)
        {
            if(pendingAction.CanDoBoth(highestPriorityActive.GetType()))
            {
                active.Add(pendingAction);
            }
        }
    }

    void RunActiveActions()
    {
        foreach(Action action in active)
        {
            action.Execute();
        }
    }

    private void Update()
    {
        UpdateActionQueuedTime();
        CheckInterrupts();
        PromoteQueuedToActive();
        RunActiveActions();
    }
}
