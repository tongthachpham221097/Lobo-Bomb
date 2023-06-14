using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDestructiblesSpawner : Spawner
{
    private static NonDestructiblesSpawner _instance;
    public static NonDestructiblesSpawner Instance => _instance;

    public static string nonDestructibles1 = "NonDestructibles_1";

    protected override void Awake()
    {
        base.Awake();
        if (NonDestructiblesSpawner._instance != null) Debug.LogError("only 1 NonDestructiblesSpawner allow to exist");
        NonDestructiblesSpawner._instance = this;
    }
}
