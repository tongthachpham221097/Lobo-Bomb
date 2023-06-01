using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class BaseMovement : LoboMonoBehaviour
{
    [Header("Base Movement")]
    [SerializeField] protected CharacterController controller;
    [SerializeField] protected Animator animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadController();
        this.LoadAnimator();
    }
    protected virtual void LoadController()
    {
        this.controller = GetComponent<CharacterController>();
    }
    protected virtual void LoadAnimator()
    {
        this.animator = GetComponent<Animator>();
    }
}
