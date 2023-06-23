using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : BaseSpawner
{
    public float _moveSpeed = 1f;

    private bool _isMovingRight = true;
    private bool _canMovingHorizontal = false;
    private bool _isMovingHorizontal = false;
    
    private bool _isMovingUp = true;
    private bool _canMovingVertical = false;
    private bool _isMovingVertical = false;

    private Vector3 _nextPosition = new Vector3();
    private Vector3Int _targetTile = new Vector3Int();

    private void Update()
    {
        this.Moving();
    }

    void Moving()
    {
        this.MovingHorizontal();
        this.MovingVertical();
    }

    void MovingVertical()
    {
        if (this._isMovingHorizontal) return;
        this.MovingUp();
        this.MovingDown();
        if(this._canMovingVertical)
        {
            this.Move();
            this._isMovingVertical = true;
        }
        else this._isMovingVertical = false;
    }

    void MovingUp()
    {
        if (!this._isMovingUp) return;
        this._nextPosition = Vector3Int.up;
        this.GetTargetTile();
        if (this.IsObstacle(this._targetTile))
        {
            this._isMovingUp = false;
            this._canMovingVertical = false;
        }
        else this._canMovingVertical = true;
    }

    void MovingDown()
    {
        if (this._isMovingUp) return;
        this._nextPosition = Vector3Int.down;
        this.GetTargetTile();
        if (this.IsObstacle(_targetTile))
        {
            this._isMovingUp = true;
            this._canMovingVertical = false;
        }
        else this._canMovingVertical = true;
    }

    void MovingHorizontal()
    {
        if (this._isMovingVertical) return;
        this.MovingLeft();
        this.MovingRight();
        if (this._canMovingHorizontal)
        {
            this._isMovingHorizontal = true;
            this.Move();
        }
        else this._isMovingHorizontal = false;

    }

    void MovingLeft()
    {
        if (this._isMovingRight) return;
        this._nextPosition = Vector3Int.left;
        this.GetTargetTile();
        if (IsObstacle(_targetTile))
        {
            this._isMovingRight = true;
            this._canMovingHorizontal = false;
            return;
        }
        this._canMovingHorizontal = true;
    }

    void MovingRight()
    {
        if (!this._isMovingRight) return;
        this._nextPosition = Vector3Int.right;
        this.GetTargetTile();
        if (IsObstacle(_targetTile))
        {
            this._isMovingRight = false;
            this._canMovingHorizontal = false;
            return;
        }
        this._canMovingHorizontal = true;
    }

    void Move()
    {
        transform.parent.Translate(this._nextPosition * _moveSpeed * Time.deltaTime);
    }

    void GetTargetTile()
    {
        Tilemap bgInWalls = this.spawnerCtrl.GameCtrl.GridSystemCtrl.BgInWalls;
        this._targetTile = bgInWalls.WorldToCell(transform.parent.position + this._nextPosition);
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
