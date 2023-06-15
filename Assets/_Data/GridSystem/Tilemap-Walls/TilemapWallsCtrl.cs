using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapWallsCtrl : LoboMonoBehaviour
{
    [SerializeField] private Tilemap _tilemapWalls;
    public Tilemap TilemapWalls => _tilemapWalls;

    [SerializeField] private WallsSpawnPoints _wallsSpawnPoints;
    public WallsSpawnPoints WallsSpawnPoints => _wallsSpawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemapWalls();
        this.LoadWallsSpawnPoints();
    }

    void LoadTilemapWalls()
    {
        if (this._tilemapWalls != null) return;
        this._tilemapWalls = GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapWalls", gameObject);
    }

    void LoadWallsSpawnPoints()
    {
        if (this._wallsSpawnPoints != null) return;
        this._wallsSpawnPoints = GetComponentInChildren<WallsSpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadWallsSpawnPoints", gameObject);
    }
}
