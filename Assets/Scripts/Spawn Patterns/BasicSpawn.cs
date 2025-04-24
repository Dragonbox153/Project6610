using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BasicSpawn : MonoBehaviour
{
    Graph graph;
    
    [SerializeField]
    GameObject Elite;
    [SerializeField]
    GameObject Berserker;
    [SerializeField]
    GameObject Grunt;

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
            Quaternion neutralRotation = new Quaternion(0, 0, 0, 0);
            Vector2 spawnPos = graph.nodes[randy].position;
            switch (formation){
                default:
                    Instantiate(Elite, spawnPos, neutralRotation);
                    Instantiate(Grunt, new Vector2(spawnPos.x + 1*Mathf.Cos(angle), spawnPos.y + 1*Mathf.Sin(angle)), neutralRotation);
                    angle += Mathf.PI;
                    Instantiate(Grunt, new Vector2(spawnPos.x + 1*Mathf.Cos(angle), spawnPos.y + 1*Mathf.Sin(angle)), neutralRotation);
                    break;

            }
            
        }
    }
}
