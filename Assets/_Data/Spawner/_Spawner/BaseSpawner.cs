using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : LoboMonoBehaviour
{
    [Header("Base Spawner")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    public SpawnerCtrl SpawnerCtrl => spawnerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
    }

    void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponentInParent<SpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnerCtrl", gameObject);
    }
}
