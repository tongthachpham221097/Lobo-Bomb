using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : BaseCtrl
{
    [SerializeField] private AvatarCtrl _avatarCtrl;
    public AvatarCtrl AvatarCtrl => _avatarCtrl;

    [SerializeField] private PlayerMovement _playerMovement;
    public PlayerMovement PlayerMovement => _playerMovement;

    [SerializeField] private PlayerAnimation _playerAnimation;
    public PlayerAnimation PlayerAnimation => _playerAnimation;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAvatarCtrl();
        this.LoadPlayerMovement();
        this.LoadPlayerAnimation();
    }

    void LoadPlayerMovement()
    {
        if (this._playerMovement != null) return;
        this._playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadPlayerMovement", gameObject);
    }

    void LoadAvatarCtrl()
    {
        if (this._avatarCtrl != null) return;
        this._avatarCtrl = GetComponentInChildren<AvatarCtrl>();
        Debug.Log(transform.name + ": LoadAvatarCtrl", gameObject);
    }

    void LoadPlayerAnimation()
    {
        if (this._playerAnimation != null) return;
        this._playerAnimation = GetComponentInChildren<PlayerAnimation>();
        Debug.Log(transform.name + ": LoadPlayerAnimation", gameObject);
    }
}
