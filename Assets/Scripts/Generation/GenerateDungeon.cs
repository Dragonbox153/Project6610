using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateDungeon : MonoBehaviour
{
    [SerializeField] Tilemap wall, floor;
    [SerializeField] RuleTile wallTile, floorTile;
    HashSet<Vector2Int> paintedFloorTiles;
    [SerializeField] int iterations, walkLength, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        RunGeneration();
    }

    public void RunGeneration()
    {
        paintedFloorTiles = new HashSet<Vector2Int>();
        Vector2Int currentLocation = new Vector2Int(0, 0);
        paintedFloorTiles.Add(currentLocation);

        for (int i = 0; i < iterations; i++) 
        {
            int runLength = Random.Range(1, walkLength);
            Vector2Int direction = Direction2D.getRandomDirection();
            

            for (int j = 0; j < runLength; j++) 
            { 
                if(currentLocation.x + direction.x < maxX && currentLocation.x + direction.x > -maxX && 
                    currentLocation.y + direction.y < maxY && currentLocation.y + direction.y > -maxY)
                {
                    currentLocation += direction;
                }
                else
                {
                    direction = -direction;
                    currentLocation += direction;
                }

                paintedFloorTiles.Add(currentLocation);
            }
        }

        foreach(Vector2Int tile in paintedFloorTiles)
        {
            floor.SetTile((Vector3Int)tile, floorTile);
        }

        for (int i = -maxX - 1; i <= maxX; i++)
        {
            for (int j = -maxY - 1;j <= maxY; j++)
            {
                currentLocation = new Vector2Int(i, j);
                if(!paintedFloorTiles.Contains(currentLocation))
                {
                    wall.SetTile((Vector3Int)currentLocation, wallTile);
                }
            }
        }
    }
}

public static class Direction2D
{
    public static List<Vector2Int> directions = new List<Vector2Int>
    {
        new Vector2Int(0,1), // UP
        new Vector2Int(1,0), // RIGHT
        new Vector2Int(0,-1), //DOWN
        new Vector2Int(-1, 0) // LEFT
    };

    public static Vector2Int getRandomDirection()
    {
        return directions[Random.Range(0, directions.Count)];
    }
}