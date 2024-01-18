using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CornScript : MonoBehaviour

{
    AudioSource jump;

    public float moveSpeed;
    public float jumpforce;

    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;
  //public GameObject DeathExplosion;
    public static bool isRunning;
  /*  public bool isSprinting = false;
    public float sprintingMultiplier;*/


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

        //Sound
        jump = GetComponent<AudioSource>();

    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
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


    //Can not run through must run face into it
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weakpoint")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Popped")
        {
            Dead();
        }
    }*/

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (isJumping && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpCount--;
            jump.Play();

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

    /*private void Dead()
    {
        Instantiate(DeathExplosion, transform.position,Quaternion.identity);

        Destroy(gameObject);
    }*/


    //Ontrigger it will you can go through
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }*/
}
