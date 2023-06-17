using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawnerCtrl : BaseSpawner
{
    [Header("FXSpawnerCtrl")]
    [SerializeField] private BombFXSpawner _bombFXSpawner;
    public BombFXSpawner BombFXSpawner => _bombFXSpawner;

    [SerializeField] private DesFXSpawner _desFXSpawner;
    public DesFXSpawner DesFXSpawner => _desFXSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBombFXSpawner();
        this.LoadDesFXSpawner();
    }

    void LoadBombFXSpawner()
    {
        if (this._bombFXSpawner != null) return;
        this._bombFXSpawner = GetComponentInChildren<BombFXSpawner>();
        Debug.LogWarning(transform.name + ": LoadBombFXSpawner", gameObject);
    }

    void LoadDesFXSpawner()
    {
        if (this._desFXSpawner != null) return;
        this._desFXSpawner = GetComponentInChildren<DesFXSpawner>();
        Debug.LogWarning(transform.name + ": LoadDesFXSpawner", gameObject);
    }
}
