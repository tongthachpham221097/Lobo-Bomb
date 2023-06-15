using System.Collections.Generic;
using UnityEngine;

public class BoxColliderSpawner : Spawner
{
    [SerializeField] protected GridSystemCtrl gridSystemCtrl;
    [SerializeField] protected List<Vector3> spawnPointsPos;
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
        this.LoadGridSystemCtrl();
    }

    void LoadGridSystemCtrl()
    {
        if (this.gridSystemCtrl != null) return;
        this.gridSystemCtrl = FindAnyObjectByType<GridSystemCtrl>();
        Debug.Log(transform.name + ": LoadGridSystemCtrl", gameObject);
    }

    private void Start()
    {
        this.ColliderSpawning();
    }

    void ColliderSpawning()
    {
        foreach(Vector3 spawnPoint in this.spawnPointsPos)
        {
            Transform prefab = this.RandomPrefab();
            Transform obj = this.Spawn(prefab, spawnPoint, transform.rotation);
            if (obj == null) return;
            obj.gameObject.SetActive(true);
        }
    }
}
