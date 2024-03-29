using UnityEngine;

public class PlayerMovement : BasePlayer
{
    [Header("Player Movement")]
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float horizontalMove;
    [SerializeField] protected float verticalMove;

    public float MoveSpeed => moveSpeed;

    protected virtual void FixedUpdate()
    {
        this.GetInput();
        this.Moving();
        this.HorizontalRotate();
    }
    protected virtual void GetInput()
    {
        this.horizontalMove = this.playerCtrl.GameCtrl.InputManager.pressHorizontal;
        this.verticalMove = this.playerCtrl.GameCtrl.InputManager.pressVertical;
    }
    protected virtual void Moving()
    {
        Vector3 move = new Vector3(horizontalMove, verticalMove, 0f) * this.moveSpeed;
        this.playerCtrl.AvatarCtrl.CharacterController.Move(move * Time.fixedDeltaTime);
    }
    protected virtual void HorizontalRotate()
    {
        if (this.horizontalMove > 0)
        {
            this.playerCtrl.AvatarCtrl.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (this.horizontalMove < 0)
        {
            this.playerCtrl.AvatarCtrl.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void UpdateRunSpeed()
    {
        this.moveSpeed += 1f;
        if (this.moveSpeed >= 5) this.playerCtrl.PlayerAnimation.SetRun();
    }
}
