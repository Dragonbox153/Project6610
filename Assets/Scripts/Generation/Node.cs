using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int id;
    public Vector2 position;

    public Node(int i_id)
    {
        id = i_id;
        position = Vector2.zero;
    }

    public Node(int i_id, Vector2 i_position)
    {
        id = i_id;
        position = i_position;
    }
}
