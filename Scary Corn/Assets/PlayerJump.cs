using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJump : MonoBehaviour
{
    AudioSource jumpSound;

    private Rigidbody2D rb;

    public int maxJumpCount;
    public float jumpSpeed, xOffset, yOffset, xSize, ySize;
    public bool isGrounded;
    public LayerMask groundMask;

    private bool isJumping = false;
    private int jumpCount;
    private float moveInput;
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        ProcessInputs();

        //Jumping
        Jump();

        jumpSound = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), new Vector2(xSize, ySize), 0f, groundMask);
        if (isGrounded)
        {
            jumpCount = maxJumpCount - 1;
        }

        
    }

    void ProcessInputs()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }

        private void Jump()
        {
        
        if (Input.GetKeyDown(KeyCode.Space) /*&& isGrounded*/ && isJumping && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = true;
            jumpCount--;
            jumpSound.Play();
        }

        isJumping = false;
        
        playerVariable.isJumping = !isGrounded;

        }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), new Vector2(xSize, ySize));
    }
}
