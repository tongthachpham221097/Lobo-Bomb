using UnityEngine;

public class SpawnerCtrl : BaseCtrl
{
    [SerializeField] private SpawnPointsInWalls _spawnPointsInWalls;
    public SpawnPointsInWalls SpawnPointsInWalls => _spawnPointsInWalls;

    [SerializeField] private DestructiblesSpawner _destructiblesSpawner;
    public DestructiblesSpawner DestructiblesSpawner => _destructiblesSpawner;

    [SerializeField] private NonDestructiblesSpawner _nonDestructiblesSpawner;
    public NonDestructiblesSpawner NonDestructiblesSpawner => _nonDestructiblesSpawner;

    [SerializeField] private BombSpawner _bombSpawner;
    public BombSpawner BombSpawner => _bombSpawner;

    [SerializeField] private FXSpawner _fxSpawner;
    public FXSpawner FXSpawner => _fxSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPointsInWalls();
        this.LoadDestructiblesSpawner();
        this.LoadNonDestructiblesSpawner();
        this.LoadBombSpawner();
        this.LoadFXSpawner();
    }

    void LoadSpawnPointsInWalls()
    {
        if (this._spawnPointsInWalls != null) return;
        this._spawnPointsInWalls = GetComponentInChildren<SpawnPointsInWalls>();
        Debug.LogWarning(transform.name + ": LoadSpawnPointsInWalls", gameObject);
    }

    void LoadDestructiblesSpawner()
    {
        if (this._destructiblesSpawner != null) return;
        this._destructiblesSpawner = GetComponentInChildren<DestructiblesSpawner>();
        Debug.LogWarning(transform.name + ": LoadDestructiblesSpawner", gameObject);
    }

    void LoadNonDestructiblesSpawner()
    {
        if (this._nonDestructiblesSpawner != null) return;
        this._nonDestructiblesSpawner = GetComponentInChildren<NonDestructiblesSpawner>();
        Debug.LogWarning(transform.name + ": LoadNonDestructiblesSpawner", gameObject);
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
}