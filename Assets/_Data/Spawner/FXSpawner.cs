using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FXSpawner : Spawner
{
    [Header("FXSpawner")]
    private static FXSpawner _instance;
    public static FXSpawner Instance => _instance;

    public static string fx1 = "FX_1";

    [SerializeField] protected int fireLength = 2;

    [SerializeField] protected Vector3 bombPosition;

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner._instance != null) Debug.LogError("only 1 FXSpawner allow to exist");
        FXSpawner._instance = this;
    }

    public virtual void Spawning(Vector3 bombPos)
    {
        this.bombPosition = bombPos;
        this.SpawnFX(bombPos);
        this.SpawnFXInAllDirections();
    }

    void SpawnFXInAllDirections()
    {
        this.SpawnFXInDirection(Vector3.up);
        this.SpawnFXInDirection(Vector3.down);
        this.SpawnFXInDirection(Vector3.left);
        this.SpawnFXInDirection(Vector3.right);
    }

    void SpawnFXInDirection(Vector3 direction)
    {
        for (int i = 1; i <= fireLength; i++)
        {
            Vector3 spawnPosition = bombPosition + (direction * i);
            
            SpawnFX(spawnPosition);
        }
    }

    private void SpawnFX(Vector3 pos)
    {
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
    }

    //void GetBombTilePosition()
    //{
    //    Vector3Int cellPosition = GridSystemCtrl.Instance.tilemapBg.WorldToCell(this.bombPosition);

    //}

}
