using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblesSpawner : Spawner
{
    private static DestructiblesSpawner _instance;
    public static DestructiblesSpawner Instance => _instance;

    public static string destructibles1 = "Destructibles_1";

    protected override void Awake()
    {
        base.Awake();
        if (DestructiblesSpawner._instance != null) Debug.LogError("only 1 DestructiblesSpawner allow to exist");
        DestructiblesSpawner._instance = this;
    }
}
