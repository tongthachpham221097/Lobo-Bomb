using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : Spawner
{
    private static BombSpawner _instance;
    public static BombSpawner Instance => _instance;

    public static string bomb1 = "Bomb_1";

    [SerializeField] private Vector3Int playerTilemapPos;
    [SerializeField] private Vector3 offsetCenter = new Vector3(0.5f, 0, 0);

    protected override void Awake()
    {
        base.Awake();
        if (BombSpawner._instance != null) Debug.LogError("only 1 BombSpawner allow to exist");
        BombSpawner._instance = this;
    }
    protected virtual void Update()
    {
        this.BombSpawning();
    }

    protected virtual void BombSpawning()
    {
        if (!InputManager.Instance.pressSpace) return;

        this.GetPlayerTilemapPos();

        Vector3 pos = this.playerTilemapPos + this.offsetCenter;
        Quaternion rot = transform.rotation;
        
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    void GetPlayerTilemapPos()
    {
        this.playerTilemapPos = GridSystemCtrl.Instance.tilemapBgOverWalls.WorldToCell(PlayerCtrl.Instance.AvatarCtrl.transform.position);
    }
}
