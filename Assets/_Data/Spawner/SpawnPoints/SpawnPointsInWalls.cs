using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnPointsInWalls : BaseSpawnPoints
{
    [SerializeField] private List<Vector3Int> spawnPointsTile = new List<Vector3Int>();
    public List<Vector3Int> SpawnPointsTile => spawnPointsTile;

    [SerializeField] private List<Vector3> spawnPointsPos = new List<Vector3>();
    public List<Vector3> SpawnPointsPos => spawnPointsPos;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.ScanTileMap();
    }

    void ScanTileMap()
    {
        this.spawnPointsTile.Clear();
        this.spawnPointsPos.Clear();
        Tilemap tilemap = this.SpawnPointsCtrl.SpawnerCtrl.GameCtrl.GridSystemCtrl.BgInWalls;
        BoundsInt bounds = tilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(tilePos);
                if (tile == null) continue;
                spawnPointsTile.Add(tilePos);

                Vector3 worldPos = tilemap.GetCellCenterWorld(tilePos);
                spawnPointsPos.Add(worldPos);
            }
        }
    }

    public bool CheckSpawnPoints(Vector3Int pos)
    {
        if(this.spawnPointsTile.Contains(pos)) return true;
        return false;
    }
}
