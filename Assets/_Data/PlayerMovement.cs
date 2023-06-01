using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : BaseMovement
{
    [Header("Player Movement")]

    [SerializeField] protected float runSpeed = 1f;
    [SerializeField] protected float horizontalMove;
    [SerializeField] protected bool jump = false;
    protected virtual void FixedUpdate()
    {
        float moveDirection = horizontalMove * runSpeed;
        Vector3 move = new Vector3(moveDirection, 0f, 0f);
        controller.Move(move * Time.fixedDeltaTime);
        this.jump = false;

        this.RotateCharacter(moveDirection);
    }
    protected virtual void Update()
    {
        this.horizontalMove = Input.GetAxisRaw("Horizontal");

        this.animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            this.jump = true;
            animator.SetBool("IsJumping", true);
        }
    }
    protected virtual void RotateCharacter(float moveDirection)
    {
        if (moveDirection > 0)
        {
            transform.parent.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveDirection < 0)
        {
            transform.parent.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
