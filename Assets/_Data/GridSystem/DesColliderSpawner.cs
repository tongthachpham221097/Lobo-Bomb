using System.Collections.Generic;
using UnityEngine;

public class DesColliderSpawner : Spawner
{
    [SerializeField] private GridSystemCtrl _gridSystemCtrl;
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
        this.LoadGridSystemCtrl();
    }

    void LoadGridSystemCtrl()
    {
        if (this._gridSystemCtrl != null) return;
        this._gridSystemCtrl = FindAnyObjectByType<GridSystemCtrl>();
        Debug.Log(transform.name + ": LoadGridSystemCtrl", gameObject);
    }

    private void Start()
    {
        this.ColliderSpawning();
    }

    void ColliderSpawning()
    {
        List<Vector3> spawnPointsPos = this._gridSystemCtrl.DesSpawnPoints.SpawnPointsPos;
        foreach(Vector3 spawnPoint in spawnPointsPos)
        {
            Transform prefab = this.RandomPrefab();
            Transform obj = this.Spawn(prefab, spawnPoint, transform.rotation);
            if (obj == null) return;
            obj.gameObject.SetActive(true);
        }
    }
}
