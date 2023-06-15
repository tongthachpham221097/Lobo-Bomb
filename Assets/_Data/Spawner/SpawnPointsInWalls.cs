using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnPointsInWalls : BaseSpawner
{
    [SerializeField] private List<Vector3Int> spawnPointsTile = new List<Vector3Int>();
    public List<Vector3Int> SpawnPointsTile => spawnPointsTile;

    [SerializeField] private List<Vector3> spawnPointsPos = new List<Vector3>();
    public List<Vector3> SpawnPointsPos => spawnPointsPos;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        ScanTileMap();
    }

    void ScanTileMap()
    {
        spawnPointsTile.Clear();
        spawnPointsPos.Clear();
        Tilemap tilemap = this.spawnerCtrl.GameCtrl.GridSystemCtrl.TilemapBgInWalls;
        BoundsInt bounds = tilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                spawnPointsTile.Add(tilePos);

                Vector3 worldPos = tilemap.GetCellCenterWorld(tilePos);
                spawnPointsPos.Add(worldPos);
            }
        }
    }

    public bool CheckSpawnPoints(Vector3Int pos)
    {
        if(spawnPointsTile.Contains(pos)) return true;
        return false;
    }
}
