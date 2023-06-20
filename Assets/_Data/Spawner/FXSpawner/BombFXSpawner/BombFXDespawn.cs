using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFXDespawn : BaseSpawner
{
    [Header("Bomb FX Despawn")]
    [SerializeField] protected float timeDelayDespawn = 3f;

    private void OnEnable()
    {
        Invoke(nameof(this.FXDespawning), this.timeDelayDespawn);
    }

    
    void FXDespawning()
    {
        this.spawnerCtrl.FXSpawnerCtrl.BombFXSpawner.Despawn(transform.parent);
    }

    
}
