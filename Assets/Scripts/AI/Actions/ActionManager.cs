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
        if (pending.Count > 0)
        {
            foreach (Action action in pending)
            {
                action.queuedTime += Time.deltaTime;
            }
        }

        if (active.Count > 0)
        {
            foreach (Action action in active)
            {
                action.queuedTime += Time.deltaTime;
            }
        }

        pending.RemoveAll(p => p.queuedTime > p.expiryTime);
        active.RemoveAll(a => a.queuedTime > a.expiryTime);
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
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Schedule(GetComponent<MeleeAttackAction>());
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            Schedule(GetComponent<PathFindAction>());
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            Schedule(GetComponent<MovementAction>());
        }

        if(Input.GetKeyUp(KeyCode.V))
        {
            Schedule(GetComponent<FireAttackAction>());
        }

        active = active.Distinct().ToList();
        UpdateActionQueuedTime();
        CheckInterrupts();
        PromoteQueuedToActive();
        RunActiveActions();
    }
}
