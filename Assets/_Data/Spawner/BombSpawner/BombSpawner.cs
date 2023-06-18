using UnityEngine;
using System.Collections;

public class BombSpawner : Spawner
{
    [SerializeField] private Vector3Int playerTilemapPos;
    [SerializeField] private Vector3 offsetCenter = new Vector3(0.5f, 0, 0);
    [SerializeField] private float timeDelayCollider = 1f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeDelay = 1f;
    }
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
        if(obj == null) return;
        obj.gameObject.SetActive(true);
        StartCoroutine(EnableColliderAfterDelay(obj.gameObject, this.timeDelayCollider));
    }

    void GetPlayerTilemapPos()
    {
        this.playerTilemapPos = this.spawnerCtrl.GameCtrl.GridSystemCtrl.BgOverWalls.WorldToCell(this.spawnerCtrl.GameCtrl.PlayerCtrl.AvatarCtrl.transform.position);
    }

    IEnumerator EnableColliderAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.GetComponentInChildren<BoxCollider>().enabled = true;
    }
}
