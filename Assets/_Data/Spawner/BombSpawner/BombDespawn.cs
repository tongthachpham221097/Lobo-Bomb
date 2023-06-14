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
        this.spawnerCtrl.FXSpawner.GetBombPosition(transform.parent.position);
        this.spawnerCtrl.FXSpawner.Spawning();
    }
}
