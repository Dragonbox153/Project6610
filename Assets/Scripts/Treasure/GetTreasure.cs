using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetTreasure : MonoBehaviour
{
    Tilemap treasure;
    [SerializeField] GameObject treasureObject;
    [SerializeField] int minTreasure, maxTreasure;
    public int totalTreasure;

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        totalTreasure = 0;
        if (treasureObject != null)
        {
            treasure = treasureObject.GetComponent<Tilemap>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPos = Vector3.zero;
        if (treasure != null && treasureObject == collision.gameObject)
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPos.x = hit.point.x - 0.01f * hit.normal.x;
                hitPos.y = hit.point.y - 0.01f * hit.normal.y;
                treasure.SetTile(treasure.WorldToCell(hitPos), null);
                totalTreasure += Random.Range(minTreasure, maxTreasure);
                Debug.Log("Total Treasure: " + totalTreasure);
            }
        }
    }
}
