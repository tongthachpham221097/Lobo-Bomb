using UnityEngine;
using UnityEngine.Tilemaps;

public class FXSpawner : Spawner
{
    [Header("FXSpawner")]
    private static FXSpawner _instance;
    public static FXSpawner Instance => _instance;

    public static string fx1 = "FX_1";

    [SerializeField] private int fireLength = 2;
    private Vector3 bombPosition;
    private Vector3Int bombPosTilemapGround;
    private Vector3 offsetCenter = new Vector3(0.5f, 0, 0);

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner._instance != null) Debug.LogError("only 1 FXSpawner allow to exist");
        FXSpawner._instance = this;
    }

    public void GetBombPosition(Vector3 bombPos)
    {
        this.bombPosition = bombPos;
        this.GetBombTilePosition();
    }

    void GetBombTilePosition()
    {
        this.bombPosTilemapGround = GridSystemCtrl.Instance.tilemapBgOverWalls.WorldToCell(this.bombPosition);
    }

    public virtual void Spawning()
    {
        this.SpawnFX(this.bombPosTilemapGround + this.offsetCenter);
        this.SpawnFXInAllDirections();
    }

    void SpawnFXInAllDirections()
    {
        this.SpawnFXDirectionUp();
        this.SpawnFXDirectionDown();
        this.SpawnFXDirectionLeft();
        this.SpawnFXDirectionRight();
    }

    void SpawnFXDirectionUp()
    {
        for (int i = 1; i <= this.fireLength; i++)
        {
            Vector3 spawnPosition = this.bombPosTilemapGround + new Vector3(0, i, 0) + this.offsetCenter;
            if (this.CheckTilemapWalls(spawnPosition)) break;
            SpawnFX(spawnPosition);
        }
    }

    void SpawnFXDirectionDown()
    {
        for (int i = 1; i <= this.fireLength; i++)
        {
            Vector3 spawnPosition = this.bombPosTilemapGround + new Vector3(0, -i, 0) + this.offsetCenter;
            if (this.CheckTilemapWalls(spawnPosition)) break;
            SpawnFX(spawnPosition);
        }
    }

    void SpawnFXDirectionLeft()
    {
        for (int i = 1; i <= this.fireLength; i++)
        {
            Vector3 spawnPosition = this.bombPosTilemapGround + new Vector3(-i, 0, 0) + this.offsetCenter;
            if (this.CheckTilemapWalls(spawnPosition)) break;
            SpawnFX(spawnPosition);
        }
    }

    void SpawnFXDirectionRight()
    {
        for (int i = 1; i <= this.fireLength; i++)
        {
            Vector3 spawnPosition = this.bombPosTilemapGround + new Vector3(i, 0, 0) + this.offsetCenter;
            if (this.CheckTilemapWalls(spawnPosition)) break;
            SpawnFX(spawnPosition);
        }
    }

    private void SpawnFX(Vector3 pos)
    {
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
    }

    bool CheckTilemapWalls(Vector3 spawnPosition)
    {
        Tilemap wall = GridSystemCtrl.Instance.tilemapWalls;
        if (wall.HasTile(wall.WorldToCell(spawnPosition))) return true;
        return false;
    }
    
}
