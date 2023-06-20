using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class BombFXDamageSender : DamageSender
{
    [Header("Bomb FX Damage Sender")]
    [SerializeField] private FXSpawnerCtrl _fxSpawnerCtrl;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] protected float timeDelayCollider = 0.3f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFXSpawnerCtrl();
        this.LoadBoxCollider();
    }

    void LoadFXSpawnerCtrl()
    {
        if (this._fxSpawnerCtrl != null) return;
        this._fxSpawnerCtrl = GetComponentInParent<FXSpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadFXSpawnerCtrl", gameObject);
    }

    void LoadBoxCollider()
    {
        if (this._boxCollider != null) return;
        this._boxCollider = GetComponent<BoxCollider>();
        this._boxCollider.isTrigger = true;
        this._boxCollider.center = new Vector3(0, 0.5f, 0);
        Debug.LogWarning(transform.name + ": LoadBoxCollider", gameObject);
    }

    private void OnEnable()
    {
        this._boxCollider.enabled = true;
        Invoke(nameof(this.OffBombFXDamageSender), this.timeDelayCollider);

    }

    void OffBombFXDamageSender()
    {
        this._boxCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;     
        this.Send(this._fxSpawnerCtrl.SpawnerCtrl.GameCtrl.PlayerCtrl.transform);
    }

}
