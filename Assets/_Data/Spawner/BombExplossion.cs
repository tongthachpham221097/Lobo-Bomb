using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplossion : LoboMonoBehaviour
{
    [SerializeField] public GameObject bombExplossion;

    [SerializeField] public float timeToExplode = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBombExplossion();
    }

    void LoadBombExplossion()
    {
        if (this.bombExplossion != null) return;
        this.bombExplossion = GameObject.Find("BombExplossion");
        Debug.LogWarning(transform.name + ": LoadBombExplossion", gameObject);
    }

    private void Update()
    {
        this.Exploding();
    }
    void Exploding()
    {
        this.timeToExplode -= Time.deltaTime;
        if (this.timeToExplode >= 0f) return;
        Instantiate(this.bombExplossion, transform.position, Quaternion.identity);
    }
}
