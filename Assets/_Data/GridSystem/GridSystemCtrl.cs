using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSystemCtrl : BaseCtrl
{
    [SerializeField] private Tilemap _tilemapBgOverWalls;
    public Tilemap TilemapBgOverWalls => _tilemapBgOverWalls;

    [SerializeField] private Tilemap _tilemapBgInWalls;
    public Tilemap TilemapBgInWalls => _tilemapBgInWalls;

    [SerializeField] private Tilemap _tilemapWalls;
    public Tilemap TilemapWalls => _tilemapWalls;

    [SerializeField] private Tilemap _tilemapNonDes;
    public Tilemap TilemapNonDes => _tilemapNonDes;

    [SerializeField] private Tilemap _destructibles;
    public Tilemap Destructibles => _destructibles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemapBgOverWalls();
        this.LoadTilemapBgInWalls();
        this.LoadTilemapWalls();
        this.LoadTilemapNonDes();
        this.LoadDestructibles();
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

    void LoadTilemapWalls()
    {
        if (this._tilemapWalls != null) return;
        this._tilemapWalls = transform.Find("Tilemap-Walls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapWalls", gameObject);
    }

    void LoadTilemapNonDes()
    {
        if (this._tilemapNonDes != null) return;
        this._tilemapNonDes = transform.Find("Non-Destructibles").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapNonDes", gameObject);
    }

    void LoadDestructibles()
    {
        if (this._destructibles != null) return;
        this._destructibles = transform.Find("Destructibles").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadDestructibles", gameObject);
    }

}
