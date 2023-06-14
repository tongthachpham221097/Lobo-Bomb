using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : Spawner
{
    public static string bomb1 = "Bomb_1";

    [SerializeField] private Vector3Int playerTilemapPos;
    [SerializeField] private Vector3 offsetCenter = new Vector3(0.5f, 0, 0);

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
        this.playerTilemapPos = GridSystemCtrl.Instance.TilemapBgOverWalls.WorldToCell(PlayerCtrl.Instance.AvatarCtrl.transform.position);
    }
}
