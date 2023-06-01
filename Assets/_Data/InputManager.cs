using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : LoboMonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    [SerializeField] protected float pressHorizontal;
    [SerializeField] protected float pressVertical;
    [SerializeField] protected float pressSpace;
    protected override void Awake()
    {
        base.Awake();
        InputManager._instance = this;
    }
    protected virtual void Update()
    {
        this.GetInput();
    }
    protected virtual void GetInput()      
    {
        this.pressHorizontal = Input.GetAxisRaw("Horizontal");
        this.pressVertical = Input.GetAxisRaw("Vertical");
        this.pressSpace = Input.GetAxisRaw("Jump");
    }
}
