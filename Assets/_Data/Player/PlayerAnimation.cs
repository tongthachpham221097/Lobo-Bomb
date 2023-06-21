using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : BasePlayer
{
    [SerializeField] protected float walkHorizontal;
    [SerializeField] protected float walkVertical;
    
    void Update()
    {
        this.WalkHorizontal();
        this.WalkVertical();
    }

    void WalkHorizontal()
    {
        this.walkHorizontal = this.playerCtrl.GameCtrl.InputManager.pressHorizontal;
        this.playerCtrl.AvatarCtrl.Animator.SetFloat("speed", Mathf.Abs(walkHorizontal));
    }

    void WalkVertical()
    {
        this.walkVertical = this.playerCtrl.GameCtrl.InputManager.pressVertical;
        if (this.walkVertical >= 0) this.WalkUp();
        if (this.walkVertical <= 0) this.WalkDown();
    }

    void WalkUp()
    {
        this.playerCtrl.AvatarCtrl.Animator.SetFloat("walkUp", Mathf.Abs(walkVertical));
    }

    void WalkDown()
    {
        this.playerCtrl.AvatarCtrl.Animator.SetFloat("walkDown", Mathf.Abs(walkVertical));
    }

    public void SetIsDead()
    {
        this.playerCtrl.AvatarCtrl.Animator.SetBool("isDead", true);
    }

    public void SetRun()
    {
        this.playerCtrl.AvatarCtrl.Animator.SetBool("isRun", true);
    }
}
