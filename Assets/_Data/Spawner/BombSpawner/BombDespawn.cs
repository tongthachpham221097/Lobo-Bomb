using UnityEngine;

public class BombDespawn : LoboMonoBehaviour
{
    [SerializeField] protected float timeDelayDespawn = 3f;

    private void OnEnable()
    {
        Invoke(nameof(this.BombDespawning), this.timeDelayDespawn);
    }

    void BombDespawning()
    {
        BombSpawner.Instance.Despawn(transform.parent);
        FXSpawner.Instance.GetBombPosition(transform.parent.position);
        FXSpawner.Instance.Spawning();
    }
}
