using UnityEngine;

public class SpawnerCtrl : BaseCtrl
{
    [SerializeField] private SpawnPointsCtrl _spawnPointsCtrl;
    public SpawnPointsCtrl SpawnPointsCtrl => _spawnPointsCtrl;

    [SerializeField] private BombSpawner _bombSpawner;
    public BombSpawner BombSpawner => _bombSpawner;

    [SerializeField] private FXSpawner _fxSpawner;
    public FXSpawner FXSpawner => _fxSpawner;

    [SerializeField] private ColliderSpawner _colliderSpawner;
    public ColliderSpawner ColliderSpawner => _colliderSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPointsCtrl();
        this.LoadBombSpawner();
        this.LoadFXSpawner();
        this.LoadColliderSpawner();
    }

    void LoadSpawnPointsCtrl()
    {
        if (this._spawnPointsCtrl != null) return;
        this._spawnPointsCtrl = GetComponentInChildren<SpawnPointsCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnPointsCtrl", gameObject);
    }

    void LoadBombSpawner()
    {
        if (this._bombSpawner != null) return;
        this._bombSpawner = GetComponentInChildren<BombSpawner>();
        Debug.LogWarning(transform.name + ": LoadBombSpawner", gameObject);
    }

    void LoadFXSpawner()
    {
        if (this._fxSpawner != null) return;
        this._fxSpawner = GetComponentInChildren<FXSpawner>();
        Debug.LogWarning(transform.name + ": LoadFXSpawner", gameObject);
    }

    void LoadColliderSpawner()
    {
        if (this._colliderSpawner != null) return;
        this._colliderSpawner = GetComponentInChildren<ColliderSpawner>();
        Debug.LogWarning(transform.name + ": LoadColliderSpawner", gameObject);
    }
}
