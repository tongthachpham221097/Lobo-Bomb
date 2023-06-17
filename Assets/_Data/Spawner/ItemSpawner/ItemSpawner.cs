using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ItemSpawner : Spawner
{
    [SerializeField] private Vector3 _desPos = new Vector3();

    public void GetDestructiblesPosition(Vector3 desPos)
    {
        this._desPos = desPos;
    }

    //public void ItemSpawning()
    //{
    //    Transform prefab = this.RandomPrefab();
    //    //Transform obj = this.Spawn(prefab, pos, rot);
    //    if (obj == null) return;
    //    obj.gameObject.SetActive(true);
    //}    
}
