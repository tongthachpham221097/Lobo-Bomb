using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]  

public class ItemDespawn : BaseSpawner
{
    [Header("Item Despawn")]
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private Vector3 _sizeBoxCollider = new Vector3(0.7f, 0.7f, 0);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    void LoadBoxCollider()
    {
        if (this._boxCollider != null) return;
        this._boxCollider = GetComponent<BoxCollider>();
        this._boxCollider.isTrigger = true;
        this._boxCollider.size = this._sizeBoxCollider;
        Debug.LogWarning(transform.name + ": LoadBoxCollider", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        this.Picking();
        this.ItemDespawning();
    }
    void ItemDespawning()
    {
        this.spawnerCtrl.ItemSpawner.Despawn(transform.parent);
    }

    void Picking()
    {
        if (transform.parent.name.Contains("Shoe")) this.PickUpShoe();
        if (transform.parent.name.Contains("Fire")) this.PickUpFire();
        if (transform.parent.name.Contains("HP")) this.PickUpHealth();
    }

    void PickUpShoe()
    {
        this.spawnerCtrl.GameCtrl.PlayerCtrl.PlayerMovement.UpdateRunSpeed();
    }

    void PickUpFire()
    {
        this.spawnerCtrl.FXSpawnerCtrl.BombFXSpawner.UpdateFireLength();
    }

    void PickUpHealth()
    {
        this.spawnerCtrl.GameCtrl.PlayerCtrl.PlayerDamageReceiver.Add();
    }
}
