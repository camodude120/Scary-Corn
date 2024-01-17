using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CornScript : MonoBehaviour

{
    public float moveSpeed;
    public float jumpforce;
    
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        jumpCount = maxJumpCount;
    }


    // Update is called once per frame
    void Update()
    {
        // get inputs
        ProcessInputs();

        //Animate
        Animate();

    }
        

       private void FixedUpdate()
        {
        isGrounded= Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }

            // Move
            Move();
        }

        void ProcessInputs()
        {
            moveDirection = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && jumpCount > 0)
            {
                isJumping = true;
            }
        }
    

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping && jumpCount >0 )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpCount--;

        }
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
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
