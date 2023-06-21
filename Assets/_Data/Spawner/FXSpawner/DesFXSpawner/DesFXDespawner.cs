using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesFXDespawner : BaseSpawner
{
    private void OnEnable()
    {
        Invoke(nameof(this.DesFXDespawning), 2f);
    }

    void DesFXDespawning()
    {
        this.spawnerCtrl.FXSpawnerCtrl.DesFXSpawner.Despawn(transform.parent);
    }
}
