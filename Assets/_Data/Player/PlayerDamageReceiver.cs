using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.hp = 3;
    }
    private void Update()
    {
        if (this.isDead) this.IsDead();
    }
    protected override void IsDead()
    {
        this.gameCtrl.PlayerCtrl.PlayerAnimation.SetIsDead();
    }
}
