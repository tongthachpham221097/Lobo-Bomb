using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : BaseSpawner
{
    public float moveSpeed = 1f;

    private bool isMovingUp = true;

    private void Update()
    {
        this.Moving();
    }

    void Moving()
    {
        Vector3 nextPosition = isMovingUp ? Vector3Int.up : Vector3Int.down;
        Tilemap bgInWalls = this.spawnerCtrl.GameCtrl.GridSystemCtrl.BgInWalls;
        Vector3Int targetTile = bgInWalls.WorldToCell(transform.parent.position + nextPosition);
        
        if (this.IsObstacle(targetTile))
        {
            isMovingUp = !isMovingUp;
        }
        else
        {
            transform.parent.Translate(nextPosition * moveSpeed * Time.deltaTime);
        }
    }
    
    bool IsObstacle(Vector3Int targetTile)
    {
        foreach(Tilemap tilemap in this.spawnerCtrl.SpawnPointsCtrl.SpawnPointsCollider.Tilemaps)
        {
            TileBase tile = tilemap.GetTile(targetTile);
            if (tile != null) return true;
        }
        return false;
    }

}
