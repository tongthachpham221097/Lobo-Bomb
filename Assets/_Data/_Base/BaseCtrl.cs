using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCtrl : LoboMonoBehaviour
{
    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => gameCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
    }

    void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = FindAnyObjectByType<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }
}
