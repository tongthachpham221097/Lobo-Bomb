using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSystemCtrl : LoboMonoBehaviour
{
    private static GridSystemCtrl _instance;
    public static GridSystemCtrl Instance => _instance;

    public Tilemap tilemapBg;
    public Tilemap tilemapWalls;

    protected override void Awake()
    {
        base.Awake();
        if (GridSystemCtrl._instance != null) Debug.LogError("only 1 GridSystemCtrl allow to exist");
        GridSystemCtrl._instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTilemapBg();
        this.LoadTilemapWalls();
    }

    void LoadTilemapBg()
    {
        if (this.tilemapBg != null) return;
        this.tilemapBg = transform.Find("Tilemap-BackGround").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapBg", gameObject);
    }

    void LoadTilemapWalls()
    {
        if (this.tilemapWalls != null) return;
        this.tilemapWalls = transform.Find("Tilemap-Walls").GetComponent<Tilemap>();
        Debug.LogWarning(transform.name + ": LoadTilemapWalls", gameObject);
    }
}
