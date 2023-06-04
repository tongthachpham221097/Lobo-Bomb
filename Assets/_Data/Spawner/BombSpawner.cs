using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : Spawner
{
    private static BombSpawner _instance;
    public static BombSpawner Instance => _instance;

    public static string bomb1 = "Bomb_1";

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

        Vector3 pos = PlayerCtrl.Instance.AvatarCtrl.transform.position;

        Quaternion rot = transform.rotation;

        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }
}
