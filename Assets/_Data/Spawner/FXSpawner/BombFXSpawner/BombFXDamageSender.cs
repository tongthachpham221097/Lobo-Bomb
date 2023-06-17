using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class BombFXDamageSender : DamageSender
{
    [SerializeField] private Tilemap _tilemap;
    
    protected override void ResetValue()
    {
        base.ResetValue();
        this.damage = 1;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBgInWalls();
    }

    void LoadBgInWalls()
    {
        if (this._tilemap != null) return;
        this._tilemap = this.GameCtrl.GridSystemCtrl.BgInWalls;
    }

    public void CheckDamageSendPlayer(Vector3 pos)
    {
        TileBase tileBombFX = this.GetTile(pos);
        if (tileBombFX == null) return;
        TileBase tilePlayer = this.GetTile(this.gameCtrl.PlayerCtrl.AvatarCtrl.transform.position);
        if(tilePlayer == null) return;
        if (tilePlayer != tileBombFX) return;
        Debug.Log(this.gameCtrl.PlayerCtrl.AvatarCtrl.transform.position);
        Debug.Log(pos);
        //this.Attack(this.gameCtrl.PlayerCtrl.gameObject, damage);
    }

    TileBase GetTile(Vector3 pos)
    {
        Vector3Int cellPosition = this._tilemap.WorldToCell(pos);
        TileBase tile = _tilemap.GetTile(cellPosition);
        return tile;
    }    
}
