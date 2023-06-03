using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : LoboMonoBehaviour
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
        this.walkHorizontal = InputManager.Instance.pressHorizontal;
        PlayerCtrl.Instance.Animator.SetFloat("speed", Mathf.Abs(walkHorizontal));
    }
    protected virtual void WalkVertical()
    {
        this.walkVertical = InputManager.Instance.pressVertical;
        if (this.walkVertical >= 0) this.WalkUp();
        if (this.walkVertical <= 0) this.WalkDown();
    }
    protected virtual void WalkUp()
    {
        PlayerCtrl.Instance.Animator.SetFloat("walkUp", Mathf.Abs(walkVertical));
    }
    protected virtual void WalkDown()
    {
        PlayerCtrl.Instance.Animator.SetFloat("walkDown", Mathf.Abs(walkVertical));
    }
}
