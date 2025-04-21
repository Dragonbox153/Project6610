using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFindAction : Action
{
    Graph graph;
    public List<Node> path = new List<Node>();
    Vector2 endPosition;

    private void Start()
    {
        graph = GameObject.Find("Grid").GetComponent<Graph>();
    }

    Node FindClosestNode(Vector2 position)
    {
        Node closest = graph.nodes.First();
        for (int n = 0; n < graph.nodes.Count; n++)
        {
            if (Vector2.Distance(position, graph.nodes[n].position) < Vector2.Distance(position, closest.position))
            {
                closest = graph.nodes[n];
            }
        }
        return closest;
    }

    void FindPath()
    {
        endPosition = GameObject.Find("Player").transform.position;
        List<Edge> children = graph.edges.FindAll(e => e.startID == path.Last().id);
        Node shortestDistChild = graph.nodes[children.First().sinkID];
        for (int e = 0; e < children.Count; e++)
        {
            if (Vector2.Distance(graph.nodes[children[e].sinkID].position, endPosition) < Vector2.Distance(shortestDistChild.position, endPosition))
            {
                shortestDistChild = graph.nodes[children[e].sinkID];
            }
        }

        path.Add(shortestDistChild);
        if (Vector2.Distance(shortestDistChild.position, endPosition) > 1)
        {
            FindPath();
        }
    }

    public override void Execute()
    {
        Node start = FindClosestNode(transform.position);
        path.Add(start);
        FindPath();
    }
}
