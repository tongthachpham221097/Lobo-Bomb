using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : LoboMonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    [SerializeField] public float pressHorizontal;
    [SerializeField] public float pressVertical;
    [SerializeField] public float pressSpace;
    protected override void Awake()
    {
        base.Awake();
        if (InputManager._instance != null) Debug.LogError("only 1 InputManager allow to exist");
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
