using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] public float pressHorizontal;
    [SerializeField] public float pressVertical;
    [SerializeField] public bool pressSpace;
 
    protected virtual void Update()
    {
        this.GetInput();
    }
    protected virtual void GetInput()      
    {
        this.pressHorizontal = Input.GetAxisRaw("Horizontal");
        this.pressVertical = Input.GetAxisRaw("Vertical");
        this.pressSpace = Input.GetButtonDown("Jump");
    }
}
