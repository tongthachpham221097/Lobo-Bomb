using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawnPoints : TilemapSpawnPoints
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemap();
        this.ScanTileMap();
    }

    void LoadTilemap()
    {
        this.tilemap = this.gridSystemCtrl.TilemapWallsCtrl.TilemapWalls;
    }

    protected override void ScanTileMap()
    {
        base.ScanTileMap();
    }
}
