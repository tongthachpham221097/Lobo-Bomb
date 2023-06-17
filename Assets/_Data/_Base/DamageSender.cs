using UnityEngine;

public class DamageSender : LoboMonoBehaviour
{
    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => gameCtrl;

    [SerializeField] protected int damage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
    }

    void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = FindAnyObjectByType<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }
    //public void Attack(GameObject target, int damage)
    //{
    //    target.GetComponentInChildren<DamageReceiver>()?.DamageReceive(damage);
    //    Debug.Log("Attack");
    //}
}
