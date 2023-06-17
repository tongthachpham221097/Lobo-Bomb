using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : LoboMonoBehaviour
{
    [Header("DamageReceiver")]
    [SerializeField] protected GameCtrl gameCtrl;

    [SerializeField] protected int hp;
    [SerializeField] protected bool isDead = false;

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

    protected virtual void DamageReceive(int damage)
    {
        this.hp -= damage;
        this.CheckDead();
    }
    
    protected virtual void CheckDead()
    {
        if (hp > 0) return;
        this.isDead = true;
        this.IsDead();
    }

    protected abstract void IsDead();
}
