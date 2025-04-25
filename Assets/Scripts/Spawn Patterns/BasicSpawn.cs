using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class BasicSpawn : MonoBehaviour
{
    Graph graph;

    [SerializeField] Tilemap walls, treasure;
    
    [SerializeField] GameObject Elite, Brute, Grunt;

    public Node nextNode;
    // Start is called before the first frame update
    void Start()
    {
        graph = GameObject.Find("Grid").GetComponent<Graph>();
    }

    // Update is called once per frame
    public void SpawnEnemies()
    {
        
        int formation = UnityEngine.Random.Range(0, 5);
        int randy = UnityEngine.Random.Range(0, graph.nodes.Count);
        float angle = UnityEngine.Random.Range(0, 2*Mathf.PI);
        Vector2 spawnPos = graph.nodes[randy].position;
        switch (formation){
            // Brute Pack
            case 0:
                InstantiateAtPos(Brute, spawnPos);
                angle += Mathf.PI / 6;
                InstantiateAtPos(Brute, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                InstantiateAtPos(Brute, new Vector2(spawnPos.x + 3.0f*Mathf.Cos(angle), spawnPos.y + 3.0f*Mathf.Sin(angle)));
                angle += 2 * Mathf.PI / 3;
                InstantiateAtPos(Brute, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                InstantiateAtPos(Brute, new Vector2(spawnPos.x + 3.0f*Mathf.Cos(angle), spawnPos.y + 3.0f*Mathf.Sin(angle)));
                break;
            // Elite Strike Team
            case 1:
                InstantiateAtPos(Elite, spawnPos);
                angle += Mathf.PI / 6;
                InstantiateAtPos(Elite, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                angle += 2 * Mathf.PI / 3;
                InstantiateAtPos(Elite, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                break;
            // Brute Circle
            case 2:
                InstantiateAtPos(Brute, spawnPos);
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.0f*Mathf.Cos(angle), spawnPos.y + 1.0f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.0f*Mathf.Cos(angle), spawnPos.y + 1.0f*Mathf.Sin(angle)));
                break;
            // Elite Double Team
            case 3:
                InstantiateAtPos(Grunt, spawnPos);
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Elite, new Vector2(spawnPos.x + 1.0f*Mathf.Cos(angle), spawnPos.y + 1.0f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Elite, new Vector2(spawnPos.x + 1.0f*Mathf.Cos(angle), spawnPos.y + 1.0f*Mathf.Sin(angle)));
                break;
            // Basic Brute Team
            case 4:
                InstantiateAtPos(Brute, spawnPos);
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.0f*Mathf.Cos(angle), spawnPos.y + 1.0f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                break;
            // Basic Elite Squad
            default:
                InstantiateAtPos(Elite, spawnPos);
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.0f*Mathf.Cos(angle), spawnPos.y + 1.0f*Mathf.Sin(angle)));
                angle += Mathf.PI / 2;
                InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1.5f*Mathf.Sin(angle)));
                break;
        }
    }

    void InstantiateAtPos(GameObject enemy, Vector2 pos)
    {
        if(!walls.HasTile(new Vector3Int((int)(pos.x), (int)(pos.y))) && !treasure.HasTile(new Vector3Int((int)(pos.x), (int)(pos.y))))
        {
            Instantiate(enemy, pos, new Quaternion(0, 0, 0, 0));
        }
    }
}
