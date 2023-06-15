using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnPointsInWalls : BaseSpawner
{
    [SerializeField] private List<Vector3Int> spawnPoints = new List<Vector3Int>();
    public List<Vector3Int> SpawnPoints => spawnPoints;
    protected override void Awake()
    {
        ScanTileMap();
    }

    void ScanTileMap()
    {
        spawnPoints.Clear();
        Tilemap tilemap = this.spawnerCtrl.GameCtrl.GridSystemCtrl.TilemapBgInWalls;
        BoundsInt bounds = tilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                spawnPoints.Add(tilePos);
            }
        }
    }

    public bool CheckSpawnPoints(Vector3Int pos)
    {
        if(spawnPoints.Contains(pos)) return true;
        return false;
    }
}
