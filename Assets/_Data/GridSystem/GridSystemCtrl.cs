using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSystemCtrl : BaseCtrl
{
    private Tilemap _tilemapBgOverWalls;
    public Tilemap TilemapBgOverWalls => _tilemapBgOverWalls;

    private Tilemap _tilemapBgInWalls;
    public Tilemap TilemapBgInWalls => _tilemapBgInWalls;

    private Tilemap _tilemapWalls;
    public Tilemap TilemapWalls => _tilemapWalls;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemapBgOverWalls();
        this.LoadTilemapBgInWalls();
        this.LoadTilemapWalls();
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
}
