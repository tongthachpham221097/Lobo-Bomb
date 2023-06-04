using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner _instance;
    public static FXSpawner Instance => _instance;

    public static string fx1 = "FX_1";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner._instance != null) Debug.LogError("only 1 FXSpawner allow to exist");
        FXSpawner._instance = this;
    }
}
