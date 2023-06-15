using System.Collections.Generic;
using UnityEngine;

public class ObstancleSpawner : Spawner
{
    [SerializeField] private Vector3 offset = new Vector3(-3, 6, 0);

    [SerializeField] private int desCount = 0;
    [SerializeField] private int maxDesCount = 75;

    [SerializeField] private int nonDesCount = 0;
    [SerializeField] private int maxNonDesCount = 25;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxSpawn = 168;
    }
    private void Start()
    {
        this.ObstacleSpawning();
    }

    void ObstacleSpawning()
    {
        List<Vector3> spawnPoints = this.SpawnerCtrl.SpawnPointsInWalls.SpawnPointsPos;
        foreach(Vector3 spawnPoint in spawnPoints)
        {
            Transform prefab = this.RandomPrefab();
            if (!this.CheckPrefabCount(prefab.name)) continue;
            
            Vector3 pos = spawnPoint + this.offset;
            Transform obj = this.Spawn(prefab, pos, transform.rotation);
            obj.gameObject.SetActive(true);
        }
    }

    bool CheckPrefabCount(string prefabName)
    {
        if (prefabName == "Empty") return true;
        if (prefabName == "Destructibles_1") return this.CheckDesCount();
        if (prefabName == "NonDestructibles_1") return this.CheckNonDesCount();
        return false;
    }

    bool CheckDesCount()
    {
        if(this.desCount > this.maxDesCount) return false;
        this.desCount++;
        return true;
    }

    bool CheckNonDesCount()
    {
        if (this.nonDesCount > this.maxNonDesCount) return false;
        this.nonDesCount++;
        return true;
    }
}
