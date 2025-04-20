using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    public int startID;
    public int sinkId;
    public float cost;

    public Edge(int i_startID, int i_sinkId, float i_cost)
    {
        startID = i_startID;
        sinkId = i_sinkId;
        cost = i_cost;
    }
}
