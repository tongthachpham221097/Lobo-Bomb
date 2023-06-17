using UnityEngine;

public class BombDespawn : BaseSpawner
{
    [SerializeField] protected float timeDelayDespawn = 3f;

    private void OnEnable()
    {
        Invoke(nameof(this.BombDespawning), this.timeDelayDespawn);
    }

    void BombDespawning()
    {
        this.spawnerCtrl.BombSpawner.Despawn(transform.parent);
        this.spawnerCtrl.FXSpawnerCtrl.BombFXSpawner.GetBombPosition(transform.parent.position);
        this.spawnerCtrl.FXSpawnerCtrl.BombFXSpawner.Spawning();
    }
}
