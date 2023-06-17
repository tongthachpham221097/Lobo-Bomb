using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSystemCtrl : BaseCtrl
{
    [SerializeField] private Tilemap _bgOverWalls;
    public Tilemap BgOverWalls => _bgOverWalls;

    [SerializeField] private Tilemap bgInWalls;
    public Tilemap BgInWalls => bgInWalls;

    [SerializeField] private Tilemap _walls;
    public Tilemap Walls => _walls;

    [SerializeField] private Tilemap _nonDestructibles;
    public Tilemap NonDestructibles => _nonDestructibles;

    [SerializeField] private Tilemap _destructibles;
    public Tilemap Destructibles => _destructibles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBgOverWalls();
        this.LoadBgInWalls();
        this.LoadWalls();
        this.LoadNonDestructibles();
        this.LoadDestructibles();
    }

    void LoadBgOverWalls()
    {
        if (this._bgOverWalls != null) return;
        this._bgOverWalls = transform.Find("BgOverWalls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapBgOverWalls", gameObject);
    }

    void LoadBgInWalls()
    {
        if (this.bgInWalls != null) return;
        this.bgInWalls = transform.Find("BgInWalls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapBgInWalls", gameObject);
    }

    void LoadWalls()
    {
        if (this._walls != null) return;
        this._walls = transform.Find("Walls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapWalls", gameObject);
    }

    void LoadNonDestructibles()
    {
        if (this._nonDestructibles != null) return;
        this._nonDestructibles = transform.Find("Non-Destructibles").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapNonDes", gameObject);
    }

    void LoadDestructibles()
    {
        if (this._destructibles != null) return;
        this._destructibles = transform.Find("Destructibles").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadDestructibles", gameObject);
    }

}
