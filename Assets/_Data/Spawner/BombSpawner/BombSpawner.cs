using UnityEngine;

public class BombSpawner : Spawner
{
    public static string bomb1 = "Bomb_1";

    [SerializeField] private Vector3Int playerTilemapPos;
    [SerializeField] private Vector3 offsetCenter = new Vector3(0.5f, 0, 0);

    protected virtual void Update()
    {
        this.BombSpawning();
    }

    protected virtual void BombSpawning()
    {
        if (!this.SpawnerCtrl.GameCtrl.InputManager.pressSpace) return;

        this.GetPlayerTilemapPos();

        Vector3 pos = this.playerTilemapPos + this.offsetCenter;
        Quaternion rot = transform.rotation;
        
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    void GetPlayerTilemapPos()
    {
        this.playerTilemapPos = this.spawnerCtrl.GameCtrl.GridSystemCtrl.TilemapBgOverWalls.WorldToCell(this.spawnerCtrl.GameCtrl.PlayerCtrl.AvatarCtrl.transform.position);
    }
}
