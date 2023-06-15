using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSpawnPoints : BaseGridSystem
{
    [SerializeField] protected List<Vector3> spawnPointsPos = new List<Vector3>();
    public List<Vector3> SpawnPointsPos => spawnPointsPos;

    [SerializeField] protected Tilemap tilemap;

    protected virtual void ScanTileMap()
    {
        this.spawnPointsPos.Clear();
        BoundsInt bounds = tilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(tilePos);
                if (tile == null) continue;
                Vector3 worldPos = tilemap.GetCellCenterWorld(tilePos);
                this.spawnPointsPos.Add(worldPos);
            }
        }
    }
}
