using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGridSystem : LoboMonoBehaviour
{
    [SerializeField] protected GridSystemCtrl gridSystemCtrl;
    public GridSystemCtrl GridSystemCtrl => gridSystemCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGridSystemCtrl();
    }

    void LoadGridSystemCtrl()
    {
        if (this.gridSystemCtrl != null) return;
        this.gridSystemCtrl = GetComponentInParent<GridSystemCtrl>();
        Debug.Log(transform.name + ": LoadGridSystemCtrl", gameObject);
    }
}
