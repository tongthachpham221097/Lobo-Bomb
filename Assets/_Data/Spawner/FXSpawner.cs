using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    [Header("FXSpawner")]
    private static FXSpawner _instance;
    public static FXSpawner Instance => _instance;

    public static string fx1 = "FX_1";

    [SerializeField] protected int fireLength = 2;

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner._instance != null) Debug.LogError("only 1 FXSpawner allow to exist");
        FXSpawner._instance = this;
    }

    public virtual void Spawning(Vector3 bombpos)
    {
        this.SpawnFX(bombpos);
        for (int i = 1; i <= this.fireLength; i++)
        {
            Vector3 pos = bombpos + new Vector3(i, 0, 0);
            this.SpawnFX(pos);

            Vector3 pos2 = bombpos + new Vector3(0, i, 0);
            this.SpawnFX(pos2);

            Vector3 pos3 = bombpos + new Vector3(-i, 0, 0);
            this.SpawnFX(pos3);

            Vector3 pos4 = bombpos + new Vector3(0, -i, 0);
            this.SpawnFX(pos4);
        }
    }
    private void SpawnFX(Vector3 pos)
    {
        Transform prefab = this.RandomPrefab();
        Transform obj = this.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
    }
}
