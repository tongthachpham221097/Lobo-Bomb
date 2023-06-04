using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BombDespawn : LoboMonoBehaviour
{
    [SerializeField] protected float timeDelayDespawn = 1f;

    private void OnEnable()
    {
        Invoke(nameof(this.BombDespawning), this.timeDelayDespawn);
    }

    void BombDespawning()
    {
        BombSpawner.Instance.Despawn(transform.parent);
        this.SpawnFX();
        
    }
    private void SpawnFX()
    {
        Transform prefab = FXSpawner.Instance.RandomPrefab();
        Transform obj = FXSpawner.Instance.Spawn(prefab, transform.position, transform.rotation);
        obj.gameObject.SetActive(true);
    }
}
