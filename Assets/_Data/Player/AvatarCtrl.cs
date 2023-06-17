using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class AvatarCtrl : BasePlayer
{
    [SerializeField] private CharacterController _characterController;
    public CharacterController CharacterController => _characterController;

    [SerializeField] private Animator _animator;
    public Animator Animator => _animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterController();
        this.LoadAnimator();
    }

    protected virtual void LoadCharacterController()
    {
        if (this._characterController != null) return;
        this._characterController = GetComponent<CharacterController>();
        Debug.Log(transform.name + ": LoadCharacterController", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this._animator != null) return;
        this._animator = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    
}
