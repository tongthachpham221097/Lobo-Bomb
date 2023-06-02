using UnityEngine;
public class BaseMovement : LoboMonoBehaviour
{
    [Header("Base Movement")]
    [SerializeField] protected CharacterController controller;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadController();
    }
    protected virtual void LoadController()
    {
        this.controller = GetComponentInParent<CharacterController>();
    }
}
