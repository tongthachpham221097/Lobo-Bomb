using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsCtrl : BaseSpawner
{
    [SerializeField] private SpawnPointsInWalls _spawnPointsInWalls;
    public SpawnPointsInWalls SpawnPointsInWalls => _spawnPointsInWalls;

    [SerializeField] private SpawnPointsCollider _spawnPointsCollider;
    public SpawnPointsCollider SpawnPointsCollider => _spawnPointsCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPointsInWalls();
        this.LoadSpawnPointsCollider();
    }

    void LoadSpawnPointsInWalls()
    {
        if (this._spawnPointsInWalls != null) return;
        this._spawnPointsInWalls = GetComponentInChildren<SpawnPointsInWalls>();
        Debug.Log(transform.name + ": LoadSpawnPointsInWalls", gameObject);
    }

    void LoadSpawnPointsCollider()
    {
        if (this._spawnPointsCollider != null) return;
        this._spawnPointsCollider = GetComponentInChildren<SpawnPointsCollider>();
        Debug.Log(transform.name + ": LoadSpawnPointsCollider", gameObject);
    }
}
