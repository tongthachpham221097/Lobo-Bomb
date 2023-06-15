using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FXSpawner : Spawner
{
    [Header("FX Spawner")]

    public static string fx1 = "FX_1";

    [SerializeField] private int fireLength = 2;
    private Vector3 _bombPosition;
    private Vector3Int _bombPosTilemapGround;
    private Vector3 offsetCenter = new Vector3(0.5f, 0, 0);

    private Dictionary<Vector3Int, bool> _spawnDirections = new Dictionary<Vector3Int, bool>();

    public void GetBombPosition(Vector3 bombPos)
    {
        this._bombPosition = bombPos;
        this.GetBombTilePosition();
    }

    void GetBombTilePosition()
    {
        this._bombPosTilemapGround = this.spawnerCtrl.GameCtrl.GridSystemCtrl.TilemapBgOverWalls.WorldToCell(this._bombPosition);
    }

    public virtual void Spawning()
    {
        this.SpawnFX(this._bombPosTilemapGround + this.offsetCenter);
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
            if (this.CheckTilemapWalls(spawnPosition)) continue;
            if (this.CheckTilemapObstacle(spawnPosition, direction)) continue;
            SpawnFX(spawnPosition + this.offsetCenter);
        }
    }

    void SpawnFX(Vector3 pos)
    {
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
    }

    bool CheckTilemapWalls(Vector3Int spawnPosition)
    {
        if (!this.spawnerCtrl.SpawnPointsInWalls.CheckSpawnPoints(spawnPosition)) return true;
        return false;
    }
    
    bool CheckTilemapObstacle(Vector3Int spawnPosition, Vector3Int direction)
    {
        if(this._spawnDirections.ContainsKey(direction) && this._spawnDirections[direction] == true) return true;
        
        TileBase tile = this.spawnerCtrl.GameCtrl.GridSystemCtrl.Destructibles.GetTile(spawnPosition);
        if (tile == null) return false;

        this._spawnDirections[direction] = true;
        
        return true;
    }
}
