using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblesSpawner : Spawner
{
    public static string destructibles1 = "Destructibles_1";

    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxSpawn = 70;
    }
}
