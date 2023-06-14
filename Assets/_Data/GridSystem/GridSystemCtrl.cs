using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSystemCtrl : LoboMonoBehaviour
{
    private static GridSystemCtrl _instance;
    public static GridSystemCtrl Instance => _instance;

    public Tilemap tilemapBgOverWalls;
    public Tilemap tilemapBgInWalls;
    public Tilemap tilemapWalls;
    public Tilemap tilemapSpawner;

    protected override void Awake()
    {
        base.Awake();
        if (GridSystemCtrl._instance != null) Debug.LogError("only 1 GridSystemCtrl allow to exist");
        GridSystemCtrl._instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemapBgOverWalls();
        this.LoadTilemapBgInWalls();
        this.LoadTilemapWalls();
        this.LoadTilemapSpawner();
    }

    void LoadTilemapBgOverWalls()
    {
        if (this.tilemapBgOverWalls != null) return;
        this.tilemapBgOverWalls = transform.Find("Tilemap-BgOverWalls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapBgOverWalls", gameObject);
    }

    void LoadTilemapBgInWalls()
    {
        if (this.tilemapBgInWalls != null) return;
        this.tilemapBgInWalls = transform.Find("Tilemap-BgInWalls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapBgInWalls", gameObject);
    }

    void LoadTilemapWalls()
    {
        if (this.tilemapWalls != null) return;
        this.tilemapWalls = transform.Find("Tilemap-Walls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapWalls", gameObject);
    }

    void LoadTilemapSpawner()
    {
        if (this.tilemapSpawner != null) return;
        this.tilemapSpawner = transform.Find("Tilemap-Spawner").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapSpawner", gameObject);
    }
}
