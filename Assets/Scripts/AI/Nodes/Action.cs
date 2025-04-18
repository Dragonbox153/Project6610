using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    List<Action> canDoSimultaneously;
    bool interupting;
    bool finished = false;

    public float queuedTime;
    public float expiryTime;
    public float priority;

    public bool CanInterupt()
    {
        return interupting;
    }

    public bool CanDoBoth(Action other)
    {
        if (canDoSimultaneously.Contains(other))
        {
            return true;
        }
        return false;
    }

    public bool IsComplete()
    {
        return finished;
    }

    virtual public void Execute() { }
}
