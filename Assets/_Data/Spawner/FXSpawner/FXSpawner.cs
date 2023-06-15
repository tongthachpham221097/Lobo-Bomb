using UnityEngine;
using UnityEngine.Tilemaps;

public class FXSpawner : Spawner
{
    [Header("FX Spawner")]

    public static string fx1 = "FX_1";

    [SerializeField] private int fireLength = 2;
    private Vector3 bombPosition;
    private Vector3Int bombPosTilemapGround;
    private Vector3 offsetCenter = new Vector3(0.5f, 0, 0);

    public void GetBombPosition(Vector3 bombPos)
    {
        this.bombPosition = bombPos;
        this.GetBombTilePosition();
    }

    void GetBombTilePosition()
    {
        this.bombPosTilemapGround = this.spawnerCtrl.GameCtrl.GridSystemCtrl.TilemapBgOverWalls.WorldToCell(this.bombPosition);
    }

    public virtual void Spawning()
    {
        this.SpawnFX(this.bombPosTilemapGround + this.offsetCenter);
        this.SpawnFXInAllDirections();
    }

    void SpawnFXInAllDirections()
    {
        SpawnFXInDirection(Vector3Int.up);
        SpawnFXInDirection(Vector3Int.down);
        SpawnFXInDirection(Vector3Int.left);
        SpawnFXInDirection(Vector3Int.right);
    }

    void SpawnFXInDirection(Vector3Int direction)
    {
        for (int i = 1; i <= this.fireLength; i++)
        {
            Vector3Int spawnPosition = this.bombPosTilemapGround + (direction * i);
            if (!this.spawnerCtrl.SpawnPointsInWalls.CheckSpawnPoints(spawnPosition)) continue;
            SpawnFX(spawnPosition + this.offsetCenter);
        }
    }

    void SpawnFX(Vector3 pos)
    {
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
    }
}
