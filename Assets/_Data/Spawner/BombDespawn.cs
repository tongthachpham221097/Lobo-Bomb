using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BombDespawn : LoboMonoBehaviour
{
    [SerializeField] protected float timeDelayDespawn = 1f;
    [SerializeField] protected int fireLength = 1;

    private void OnEnable()
    {
        Invoke(nameof(this.BombDespawning), this.timeDelayDespawn);
    }

    void BombDespawning()
    {
        BombSpawner.Instance.Despawn(transform.parent);
        this.SpawningFX();
        
    }

    void SpawningFX()
    {
        this.SpawnFX(transform.position);
        for(int i = 1; i <= this.fireLength; i++)
        {
            Vector3 pos = transform.position + new Vector3(i, 0, 0);
            this.SpawnFX(pos);

            Vector3 pos2 = transform.position + new Vector3(0, i, 0);
            this.SpawnFX(pos2);

            Vector3 pos3 = transform.position + new Vector3(-i, 0, 0);
            this.SpawnFX(pos3);

            Vector3 pos4 = transform.position + new Vector3(0, -i, 0);
            this.SpawnFX(pos4);
        }
    }    
    private void SpawnFX(Vector3 pos)
    {
        Transform prefab = FXSpawner.Instance.RandomPrefab();
        Transform obj = FXSpawner.Instance.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
    }
}
