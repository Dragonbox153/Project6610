using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    protected List<Type> canDoSimultaneously = new List<Type>();
    protected bool interupting;
    protected bool finished = false;

    public float queuedTime;
    public float expiryTime;
    public int priority;

    public bool CanInterupt()
    {
        return interupting;
    }

    public bool CanDoBoth(Type other)
    {
        if (canDoSimultaneously.Count > 0 && canDoSimultaneously.Contains(other))
        {
            return true;
        }
        return false;
    }

    public bool IsComplete()
    {
        return finished;
    }

    public virtual void Execute() { }
}
