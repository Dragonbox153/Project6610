using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    public int startID;
    public int sinkID;
    public float cost;

    public Edge(int i_startID, int i_sinkId)
    {
        startID = i_startID;
        sinkID = i_sinkId;
    }
}
