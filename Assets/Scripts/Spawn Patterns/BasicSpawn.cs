using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class BasicSpawn : MonoBehaviour
{
    Graph graph;

    [SerializeField] Tilemap walls, treasure;
    
    [SerializeField] GameObject Elite, Berserker, Grunt;

    public Node nextNode;
    // Start is called before the first frame update
    void Start()
    {
        graph = GameObject.Find("Grid").GetComponent<Graph>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            int formation = Random.Range(0, 4);
            int randy = Random.Range(0, graph.nodes.Count);
            float angle = Random.Range(0, 2*Mathf.PI);
            Vector2 spawnPos = graph.nodes[randy].position;
            switch (formation){
                default:
                    InstantiateAtPos(Elite, spawnPos);
                    InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1*Mathf.Sin(angle)));
                    angle += Mathf.PI;
                    InstantiateAtPos(Grunt, new Vector2(spawnPos.x + 1.5f*Mathf.Cos(angle), spawnPos.y + 1*Mathf.Sin(angle)));
                    break;
            }
            
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
