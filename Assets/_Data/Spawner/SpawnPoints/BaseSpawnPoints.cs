using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnPoints : LoboMonoBehaviour
{
    [SerializeField] protected SpawnPointsCtrl spawnPointsCtrl;
    public SpawnPointsCtrl SpawnPointsCtrl => spawnPointsCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPointsCtrl();
    }

    void LoadSpawnPointsCtrl()
    {
        if (this.spawnPointsCtrl != null) return;
        this.spawnPointsCtrl = GetComponentInParent<SpawnPointsCtrl>();
        Debug.Log(transform.name + ": LoadSpawnPointsCtrl", gameObject);
    }
}
