using UnityEngine;

public class BombDespawn : BaseSpawner
{
    [SerializeField] private BoxCollider _boxCollider;

    [SerializeField] private float _timeDelayDespawn = 3f;
    [SerializeField] private float timeDelayCollider = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    void LoadBoxCollider()
    {
        if (this._boxCollider != null) return;
        this._boxCollider = transform.parent.GetComponentInChildren<BoxCollider>();
    }

    private void OnEnable()
    {
        Invoke(nameof(this.BombDespawning), this._timeDelayDespawn);
        Invoke(nameof(this.OnColliderOfBomb), this.timeDelayCollider);
    }

    void BombDespawning()
    {
        this.spawnerCtrl.BombSpawner.Despawn(transform.parent);
        this.OffColliderOfBomb();
        this.spawnerCtrl.FXSpawnerCtrl.BombFXSpawner.GetBombPosition(transform.parent.position);
        this.spawnerCtrl.FXSpawnerCtrl.BombFXSpawner.Spawning();
    }

    void OnColliderOfBomb()
    {
        this._boxCollider.enabled = true;
    } 

    void OffColliderOfBomb()
    {
        this._boxCollider.enabled = false;
    }
}
