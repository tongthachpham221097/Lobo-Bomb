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

    [SerializeField] private PlayerDamageReceiver _playerDamageReceiver;
    public PlayerDamageReceiver PlayerDamageReceiver => _playerDamageReceiver;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAvatarCtrl();
        this.LoadPlayerMovement();
        this.LoadPlayerAnimation();
        this.LoadPlayerDamageReceiver();
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

    void LoadPlayerDamageReceiver()
    {
        if (this._playerDamageReceiver != null) return;
        this._playerDamageReceiver = GetComponentInChildren<PlayerDamageReceiver>();
        Debug.Log(transform.name + ": LoadPlayerDamageReceiver", gameObject);
    }
}
