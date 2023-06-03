using UnityEngine;

public class PlayerMovement : LoboMonoBehaviour
{
    [Header("Player Movement")]

    [SerializeField] protected float runSpeed = 1f;
    [SerializeField] protected float horizontalMove;
    [SerializeField] protected float verticalMove;
    protected virtual void FixedUpdate()
    {
        this.GetInput();
        this.Moving();
        this.HorizontalRotate();
    }
    protected virtual void GetInput()
    {
        this.horizontalMove = InputManager.Instance.pressHorizontal;
        this.verticalMove = InputManager.Instance.pressVertical;
    }
    protected virtual void Moving()
    {
        Vector3 move = new Vector3(horizontalMove, verticalMove, 0f) * this.runSpeed;
        PlayerCtrl.Instance.CharacterController.Move(move * Time.fixedDeltaTime);
    }
    protected virtual void HorizontalRotate()
    {
        if (this.horizontalMove > 0)
        {
            PlayerCtrl.Instance.AvatarCtrl.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (this.horizontalMove < 0)
        {
            PlayerCtrl.Instance.AvatarCtrl.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
