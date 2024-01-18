using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerWalk : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    private bool facingRight = true;
    public float moveSpeed;
    public PlayerSprint sprint;

    public float maxMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = maxMoveSpeed;

        if (playerVariable.isHitting[0] || playerVariable.isHitting[1] || playerVariable.isHitting[2])
        {
            moveSpeed = maxMoveSpeed * 0.5f;
        }
        if (sprint.stamina > 0 && playerVariable.isSprinting)
        {
            moveSpeed *= 2;
        }

        ProcessInputs();

        Walk();

        Animate();

        
    }

    private void Walk()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput != 0)
        {
            playerVariable.isWalking = true;
        }
        else
        {
            playerVariable.isWalking = false;
        }
    }

    private void ProcessInputs()
    {
        moveInput = Input.GetAxis("Horizontal");
    }

    private void Animate()
    {
        if (moveInput > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveInput < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
