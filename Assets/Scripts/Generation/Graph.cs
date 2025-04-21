using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Graph : MonoBehaviour
{
    public List<Node> nodes = new List<Node>();
    public List<Edge> edges = new List<Edge>();
    [SerializeField] GenerateDungeon dungeonGenerator;

    public void MakeGraph()
    {
        int currID = 0;
        for(int x = -dungeonGenerator.maxX; x < dungeonGenerator.maxX; x++)
        {
            for(int y = -dungeonGenerator.maxY; y < dungeonGenerator.maxY; y++)
            {
                if (dungeonGenerator.floor.HasTile(new Vector3Int(x, y, 0))) {
                    nodes.Add(new Node(currID, new Vector2(x, y)));
                    MakeConnections(nodes.Last());

                    currID++;
                }
            }
        }

        print(nodes.First().position);
        print(nodes.Last().position);
    }

    void MakeConnections(Node node)
    {
        if (nodes.Any(n => n.position == new Vector2(node.position.x - 1, node.position.y)))
        {
            Node left = nodes.Find(n => n.position == new Vector2(node.position.x - 1, node.position.y));
            edges.Add(new Edge(node.id, left.id));
            edges.Add(new Edge(left.id, node.id));
        }
        if (nodes.Any(n => n.position == new Vector2(node.position.x, node.position.y - 1)))
        {
            Node down = nodes.Find(n => n.position == new Vector2(node.position.x, node.position.y - 1));
            edges.Add(new Edge(node.id, down.id));
            edges.Add(new Edge(down.id, node.id));
        }
    }
}
