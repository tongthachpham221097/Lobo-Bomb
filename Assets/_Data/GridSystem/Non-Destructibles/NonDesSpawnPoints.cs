using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NonDesSpawnPoints : TilemapSpawnPoints
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemap();
        this.ScanTileMap();
    }

    void LoadTilemap()
    {
        this.tilemap = this.gridSystemCtrl.NonDestructiblesCtrl.NonDestructibles;
    }
    protected override void ScanTileMap()
    {
        base.ScanTileMap();
    }
}
