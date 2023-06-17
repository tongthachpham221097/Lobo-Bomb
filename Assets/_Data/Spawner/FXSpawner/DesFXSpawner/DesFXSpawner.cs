using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DesFXSpawner : Spawner
{
    public void DesFXspawning(Vector3 pos)
    {
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
        this.spawnerCtrl.ItemSpawner.ItemSpawning(pos + new Vector3(0, 0.5f, 0));
    }
}
