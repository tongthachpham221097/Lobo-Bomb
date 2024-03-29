﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class BombFXSpawner : Spawner
{
    [Header("FX Spawner")]

    [SerializeField] private int fireLength = 2;
    [SerializeField] private Dictionary<Vector3Int, bool> _spawnDirections = new Dictionary<Vector3Int, bool>();

    private Vector3 _bombPosition;
    private Vector3Int _bombPosTilemapGround;
    private Vector3 offsetCenter = new Vector3(0.5f, 0, 0);
    private Vector3 offsetTilemap = new Vector3(0.5f, 0.5f, 0);

    private Transform _collider;

    public void GetBombPosition(Vector3 bombPos)
    {
        this._bombPosition = bombPos;
        this.GetBombTilePosition();
    }

    void GetBombTilePosition()
    {
        this._bombPosTilemapGround = this.spawnerCtrl.GameCtrl.GridSystemCtrl.BgOverWalls.WorldToCell(this._bombPosition);
    }

    public virtual void Spawning()
    {
        this.BombSpawnFX(this._bombPosTilemapGround + this.offsetCenter);
        this.SpawnFXInAllDirections();
    }

    void SpawnFXInAllDirections()
    {
        this._spawnDirections.Clear();

        SpawnFXInDirection(Vector3Int.up);
        SpawnFXInDirection(Vector3Int.down);
        SpawnFXInDirection(Vector3Int.left);
        SpawnFXInDirection(Vector3Int.right);
    }

    void SpawnFXInDirection(Vector3Int direction)
    {
        for (int i = 1; i <= this.fireLength; i++)
        {
            Vector3Int spawnPosition = this._bombPosTilemapGround + (direction * i);
            if (this.CheckTilemapObstacle(spawnPosition, direction)) continue;
            this.BombSpawnFX(spawnPosition + this.offsetCenter);
        }
    }

    void BombSpawnFX(Vector3 pos)
    {
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
    }
    
    bool CheckTilemapObstacle(Vector3Int spawnPosition, Vector3Int direction)
    {
        if (this._spawnDirections.ContainsKey(direction) && this._spawnDirections[direction] == true) return true;

        if(!this.CheckColliderSpawner(spawnPosition + this.offsetTilemap)) return false;
        if (!this._collider.gameObject.activeSelf) return false;
        this.CheckDestructibles(spawnPosition);
        this._spawnDirections[direction] = true;
        return true;
    }

    void CheckDestructibles(Vector3Int spawnPosition)
    {
        Tilemap tilemap = this.spawnerCtrl.GameCtrl.GridSystemCtrl.Destructibles;
        Vector3Int cellPosition = tilemap.WorldToCell(spawnPosition);
        TileBase tile = tilemap.GetTile(cellPosition);
        if (tile == null) return;
        tilemap.SetTile(cellPosition, null);

        this.spawnerCtrl.FXSpawnerCtrl.DesFXSpawner.DesFXspawning(spawnPosition + this.offsetCenter);
        this.ColliderDespawn(spawnPosition);
    }

    void ColliderDespawn(Vector3Int spawnPosition)
    {
        Vector3 pos = spawnPosition + this.offsetTilemap;
        if (!this.CheckColliderSpawner(pos)) return;
        this.Despawn(this._collider);
        this.BombSpawnFX(spawnPosition + this.offsetCenter);
    }

    bool CheckColliderSpawner(Vector3 pos)
    {
        foreach (Transform collider in this.spawnerCtrl.ColliderSpawner.Holder)
        {
            if (collider.position != pos) continue;
            this._collider = collider;
            return true;
        }
        return false;
    }

    public void UpdateFireLength()
    {
        this.fireLength += 1;
    }
}
