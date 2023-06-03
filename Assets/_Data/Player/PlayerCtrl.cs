using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : LoboMonoBehaviour
{
    private static PlayerCtrl _instance;
    public static PlayerCtrl Instance => _instance;

    [SerializeField] protected CharacterController characterController;
    public CharacterController CharacterController => characterController;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;

    [SerializeField] protected AvatarCtrl avatarCtrl;
    public AvatarCtrl AvatarCtrl => avatarCtrl;
    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl._instance != null) Debug.LogError("only 1 PlayerCtrl allow to exist");
        PlayerCtrl._instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadCharacterController();
        this.LoadPlayerMovement();
        this.LoadAvatarCtrl();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.Find("AvatarCtrl").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    protected virtual void LoadCharacterController()
    {
        if (this.characterController != null) return;
        this.characterController = transform.Find("AvatarCtrl").GetComponent<CharacterController>();
        Debug.Log(transform.name + ": LoadCharacterController", gameObject);
    }
    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadPlayerMovement", gameObject);
    }
    protected virtual void LoadAvatarCtrl()
    {
        if (this.avatarCtrl != null) return;
        this.avatarCtrl = GetComponentInChildren<AvatarCtrl>();
        Debug.Log(transform.name + ": LoadAvatarCtrl", gameObject);
    }
}
