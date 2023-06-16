using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColliderSpawner : Spawner
{
    [SerializeField] private List<Vector3> _spawnPoints = new List<Vector3>();
    [SerializeField] private List<Transform> colliders = new List<Transform>();
    public List<Transform> Colliders => colliders;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
        this.SpawnCollider();
        this.LoadColliders();
    }

    void LoadSpawnPoints()
    {
        this._spawnPoints = this.spawnerCtrl.SpawnPointsCtrl.SpawnPointsCollider.SpawnPoints;
    }

    void SpawnCollider()
    {
        foreach (Vector3 spawnPoint in _spawnPoints)
        {
            Transform prefab = this.RandomPrefab();
            Transform obj = this.Spawn(prefab, spawnPoint, transform.rotation);
            if (obj == null) return;
            obj.gameObject.SetActive(true);
        }
    }

    void LoadColliders()
    {
        foreach(Transform collider in this.holder)
        {
            this.colliders.Add(collider);
        }
    }
}
