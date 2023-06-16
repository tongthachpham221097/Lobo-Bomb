using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : LoboMonoBehaviour
{
    [SerializeField] private PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    [SerializeField] private InputManager inputManager;
    public InputManager InputManager => inputManager;

    [SerializeField] private GridSystemCtrl gridSystemCtrl;
    public GridSystemCtrl GridSystemCtrl => gridSystemCtrl;

    [SerializeField] private SpawnerCtrl spawnerCtrl;
    public SpawnerCtrl SpawnerCtrl => spawnerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadInputManager();
        this.LoadGridSystemCtrl();
        this.LoadSpawnerCtrl();
    }

    void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = FindAnyObjectByType<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    void LoadInputManager()
    {
        if (this.inputManager != null) return;
        this.inputManager = FindAnyObjectByType<InputManager>();
        Debug.Log(transform.name + ": LoadInputManager", gameObject);
    }

    void LoadGridSystemCtrl()
    {
        if (this.gridSystemCtrl != null) return;
        this.gridSystemCtrl = FindAnyObjectByType<GridSystemCtrl>();
        Debug.Log(transform.name + ": LoadGridSystemCtrl", gameObject);
    }

    void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = FindAnyObjectByType<SpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSpawnerCtrl", gameObject);
    }
}
