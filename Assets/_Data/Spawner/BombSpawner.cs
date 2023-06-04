using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : Spawner
{
    public static string bomb1 = "Bomb_1";

    protected virtual void Update()
    {
        this.ObstacleSpawning();
    }

    protected virtual void ObstacleSpawning()
    {
        if (!InputManager.Instance.pressSpace) return;

        Vector3 pos = PlayerCtrl.Instance.AvatarCtrl.transform.position;

        Quaternion rot = transform.rotation;

        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }
}
