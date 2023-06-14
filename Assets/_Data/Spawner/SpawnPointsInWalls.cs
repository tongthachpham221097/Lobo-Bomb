using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnPointsInWalls : MonoBehaviour
{
    [SerializeField] private List<Vector3Int> spawnPointsInWalls = new List<Vector3Int>();

    void Start()
    {
        ScanTileMap();
    }

    void ScanTileMap()
    {
        spawnPointsInWalls.Clear();
        Tilemap tilemap = GridSystemCtrl.Instance.tilemapBgInWalls;
        BoundsInt bounds = tilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                spawnPointsInWalls.Add(tilePos);
            }
        }
    }
}
