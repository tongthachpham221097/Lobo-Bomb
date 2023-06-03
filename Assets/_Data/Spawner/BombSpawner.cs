using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : LoboMonoBehaviour
{
    public Tilemap tilemap;
    public GameObject bombPrefab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBombPrefab();
        //this.LoadTilemap();
    }

    void LoadBombPrefab()
    {
        if (this.bombPrefab != null) return;
        this.bombPrefab = GameObject.Find("BombPrefab");
        this.bombPrefab.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadBombPrefab", gameObject);
    }

    //void LoadTilemap()
    //{
    //    if (this.tilemap != null) return;
    //    this.tilemap = GameObject.Find("Tilemap-BackGround");
    //    this.bombPrefab.SetActive(false);
    //    Debug.LogWarning(transform.name + ": LoadBombPrefab", gameObject);
    //}

    private void Update()
    {
        if (InputManager.Instance.pressSpace == 1) this.SpawnBomb();
    }
    void SpawnBomb()
    {
        Vector3Int cell = tilemap.WorldToCell(PlayerCtrl.Instance.transform.position);
        Vector3 cellCenter = tilemap.WorldToCell(cell);

        Instantiate(this.bombPrefab, cellCenter, Quaternion.identity);
        this.bombPrefab.SetActive(true);
    }
}
