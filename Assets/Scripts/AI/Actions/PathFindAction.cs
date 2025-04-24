using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFindAction : Action
{
    Graph graph;
    public Node nextNode;
    Vector2 playerPosition;
    public float distFromPlayerStop;

    private bool isPathFound;

    private void Start()
    {
        graph = GameObject.Find("Grid").GetComponent<Graph>();
        nextNode = FindClosestNode(transform.position);
        interupting = false;
    }

    public bool DidIFindPath()
    {
        return isPathFound;
    }

    public void finishPath()
    {
        isPathFound = false;
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

    void FindNextNode()
    {
        if(!isPathFound)
        {
            playerPosition = GameObject.Find("Player").transform.position;
            List<Edge> children = graph.edges.FindAll(e => e.startID == nextNode.id);
            Node closestChildToPlayer = graph.nodes[children[0].sinkID];
            foreach (Edge e in children)
            {
                if (Vector2.Distance(graph.nodes[e.sinkID].position, playerPosition) < Vector2.Distance(closestChildToPlayer.position, playerPosition))
                {
                    closestChildToPlayer = graph.nodes[e.sinkID];
                }
            }
            nextNode = closestChildToPlayer;

            print(nextNode.position);

            GetComponent<MovementAction>().nextNode = nextNode;
        }
    }

    public override void Execute()
    {
        FindNextNode();
        isPathFound = true;   
        finished = true;
    }
}
