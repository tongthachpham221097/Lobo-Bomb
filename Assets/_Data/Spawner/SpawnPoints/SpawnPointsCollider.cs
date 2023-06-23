using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnPointsCollider : BaseSpawnPoints
{
    [SerializeField] private List<Tilemap> _tilemaps = new List<Tilemap>();

    [SerializeField] private List<Vector3> _spawnPoints = new List<Vector3>();
    public List<Vector3> SpawnPoints => _spawnPoints;
    public List<Tilemap> Tilemaps => _tilemaps;
         
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemap();
        this.LoadSpawnPoints();
    }

    void LoadTilemap()
    {
        if (this._tilemaps.Count > 0) return;
        this._tilemaps.Add(this.SpawnPointsCtrl.SpawnerCtrl.GameCtrl.GridSystemCtrl.Walls);
        this._tilemaps.Add(this.SpawnPointsCtrl.SpawnerCtrl.GameCtrl.GridSystemCtrl.NonDestructibles);
        this._tilemaps.Add(this.SpawnPointsCtrl.SpawnerCtrl.GameCtrl.GridSystemCtrl.Destructibles);
    }

    void LoadSpawnPoints()
    {
        if (this._spawnPoints.Count > 0) return;
        foreach (var tilemap in this._tilemaps)
        {
            this.ScanTileMap(tilemap);
        }
    }

    void ScanTileMap(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(tilePos);
                if (tile == null) continue;
                Vector3 worldPos = tilemap.GetCellCenterWorld(tilePos);
                this._spawnPoints.Add(worldPos);
            }
        }
    }
}
