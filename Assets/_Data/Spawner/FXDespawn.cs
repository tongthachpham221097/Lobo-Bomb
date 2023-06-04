using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : MonoBehaviour
{
    [SerializeField] protected float timeDelayDespawn = 3f;

    private void OnEnable()
    {
        Invoke(nameof(this.FXDespawning), this.timeDelayDespawn);
    }

    void FXDespawning()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
