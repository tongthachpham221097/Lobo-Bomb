using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NonDestructiblesCtrl : LoboMonoBehaviour
{
    [SerializeField] private NonDesSpawnPoints _nonDesSpawnPoints;
    public NonDesSpawnPoints NonDesSpawnPoints => _nonDesSpawnPoints;

    [SerializeField] private Tilemap _nonDestructibles;
    public Tilemap NonDestructibles => _nonDestructibles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNonDesSpawnPoints();
        this.LoadNonDestructibles();
    }

    void LoadNonDesSpawnPoints()
    {
        if (this._nonDesSpawnPoints != null) return;
        this._nonDesSpawnPoints = GetComponentInChildren<NonDesSpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadNonDesSpawnPoints", gameObject);
    }

    void LoadNonDestructibles()
    {
        if (this._nonDestructibles != null) return;
        this._nonDestructibles = GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadDesSpawnPoints", gameObject);
    }
}
