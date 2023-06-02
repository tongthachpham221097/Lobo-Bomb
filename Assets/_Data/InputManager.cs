using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : LoboMonoBehaviour
{
    public static InputManager instance;

    [SerializeField] public float pressHorizontal;
    [SerializeField] public float pressVertical;
    [SerializeField] public float pressSpace;
    protected override void Awake()
    {
        base.Awake();
        InputManager.instance = this;
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
