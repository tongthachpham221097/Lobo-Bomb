using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsColliderSpawner : BoxColliderSpawner
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPointsPos();
    }

    void LoadSpawnPointsPos()
    {
        this.spawnPointsPos = this.gridSystemCtrl.NonDesSpawnPoints.SpawnPointsPos;
    }
}
