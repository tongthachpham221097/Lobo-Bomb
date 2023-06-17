using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColliderSpawner : Spawner
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.SpawnCollider();
    }

    void SpawnCollider()
    {
        if (this.holder.childCount > 0) return;
        foreach (Vector3 spawnPoint in this.spawnerCtrl.SpawnPointsCtrl.SpawnPointsCollider.SpawnPoints)
        {
            Transform prefab = this.RandomPrefab();
            Transform obj = this.Spawn(prefab, spawnPoint, transform.rotation);
            if (obj == null) return;
            //if(this.IsObjectInHolder(obj)) return;
            obj.gameObject.SetActive(true);
        }
    }

    bool IsObjectInHolder(Transform obj)
    {
        foreach(Transform collider in this.holder)
        {
            if(collider.position != obj.position) continue;
            Destroy(obj.gameObject);
            return true;
        }
        return false;
    }
}
