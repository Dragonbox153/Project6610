using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EvadeMeleeAction : Action
{
    [SerializeField] Tilemap treasure;
    Graph graph;
    public Node nextNode;
    Vector2 playerPosition;
    public float distFromPlayerStop;

    private bool isPathFound;

    public EnemyMovement enemyMovement;
    public float distanceThreshold;

    private void Start()
    {
        treasure = GameObject.Find("Treasure").GetComponent<Tilemap>();
        graph = GameObject.Find("Grid").GetComponent<Graph>();
        nextNode = FindClosestNode(transform.position);
        canDoSimultaneously.Add(typeof(MeleeAttackAction));
        interupting = false;
    }

    // Removal of this has been known to cause the code for finding the next node to bug out.
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
                if (Vector2.Distance(graph.nodes[e.sinkID].position, playerPosition) == Vector2.Distance(closestChildToPlayer.position, playerPosition)
                    && !treasure.HasTile(new Vector3Int((int)(graph.nodes[e.sinkID].position.x - 0.5f), (int)(graph.nodes[e.sinkID].position.y - 0.5f), 0)))
                {
                    closestChildToPlayer = graph.nodes[e.sinkID];
                }
            }
            nextNode = closestChildToPlayer;

            print(nextNode.position);
        }
    }

    public override void Execute()
    {
        FindNextNode();
        isPathFound = true;   

        Vector2 playerPoint = GameObject.Find("Player").transform.position;
        Vector2 myPoint = gameObject.transform.position;

        GetComponent<ActionManager>().Schedule(new ActionNode(GetComponent<MeleeAttackAction>()).GetAction());

        if(Vector2.Distance(transform.position, nextNode.position) > distanceThreshold)
        {
            GameObject enemy = enemyMovement.gameObject;
            enemyMovement.acceleration = new Vector2(nextNode.position.x - enemy.transform.position.x, nextNode.position.y - enemy.transform.position.y).normalized;
            enemyMovement.acceleration *= 4 * enemyMovement.speed;
        }
        else
        {
            isPathFound = false;
            enemyMovement.acceleration = Vector2.zero;
        }

        finished = true;
    }
}