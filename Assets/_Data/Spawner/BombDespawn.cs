using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

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
        FXSpawner.Instance.Spawning(transform.parent.position);
    }
}
