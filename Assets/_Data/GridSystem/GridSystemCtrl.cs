using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSystemCtrl : BaseCtrl
{
    [SerializeField] private Tilemap _tilemapBgOverWalls;
    public Tilemap TilemapBgOverWalls => _tilemapBgOverWalls;

    [SerializeField] private Tilemap _tilemapBgInWalls;
    public Tilemap TilemapBgInWalls => _tilemapBgInWalls;

    [SerializeField] private TilemapWallsCtrl _tilemapWallsCtrl;
    public TilemapWallsCtrl TilemapWallsCtrl => _tilemapWallsCtrl;

    [SerializeField] private Tilemap _destructibles;
    public Tilemap Destructibles => _destructibles;

    [SerializeField] private NonDestructiblesCtrl _nonDestructiblesCtrl;
    public NonDestructiblesCtrl NonDestructiblesCtrl => _nonDestructiblesCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemapBgOverWalls();
        this.LoadTilemapBgInWalls();
        this.LoadTilemapWallsCtrl();
        this.LoadDestructibles();
        this.LoadNonDestructiblesCtrl();
    }

    void LoadTilemapBgOverWalls()
    {
        if (this._tilemapBgOverWalls != null) return;
        this._tilemapBgOverWalls = transform.Find("Tilemap-BgOverWalls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapBgOverWalls", gameObject);
    }

    void LoadTilemapBgInWalls()
    {
        if (this._tilemapBgInWalls != null) return;
        this._tilemapBgInWalls = transform.Find("Tilemap-BgInWalls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapBgInWalls", gameObject);
    }

    void LoadTilemapWallsCtrl()
    {
        if (this._tilemapWallsCtrl != null) return;
        this._tilemapWallsCtrl = GetComponentInChildren<TilemapWallsCtrl>();
        Debug.LogWarning(transform.name + ": LoadTilemapWallsCtrl", gameObject);
    }

    void LoadDestructibles()
    {
        if (this._destructibles != null) return;
        this._destructibles = transform.Find("Destructibles").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadDestructibles", gameObject);
    }

    void LoadNonDestructiblesCtrl()
    {
        if (this._nonDestructiblesCtrl != null) return;
        this._nonDestructiblesCtrl = GetComponentInChildren<NonDestructiblesCtrl>();
        Debug.LogWarning(transform.name + ": LoadNonDestructiblesCtrl", gameObject);
    }
}
