using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : BasePlayer
{
    [SerializeField] protected float walkHorizontal;
    [SerializeField] protected float walkVertical;
    protected virtual void Update()
    {
        this.WalkHorizontal();
        this.WalkVertical();
    }
    protected virtual void WalkHorizontal()
    {
        this.walkHorizontal = this.playerCtrl.GameCtrl.InputManager.pressHorizontal;
        this.playerCtrl.Animator.SetFloat("speed", Mathf.Abs(walkHorizontal));
    }
    protected virtual void WalkVertical()
    {
        this.walkVertical = this.playerCtrl.GameCtrl.InputManager.pressVertical;
        if (this.walkVertical >= 0) this.WalkUp();
        if (this.walkVertical <= 0) this.WalkDown();
    }
    protected virtual void WalkUp()
    {
        this.playerCtrl.Animator.SetFloat("walkUp", Mathf.Abs(walkVertical));
    }
    protected virtual void WalkDown()
    {
        this.playerCtrl.Animator.SetFloat("walkDown", Mathf.Abs(walkVertical));
    }
}
