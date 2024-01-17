using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    AudioSource jump;

    private Rigidbody2D rb;

    public float jumpSpeed, xOffset, yOffset, xSize, ySize;
    public bool isGrounded;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping
        Jump();

        jump = GetComponent<AudioSource>();
    }

    private void JumpSound()
    {
        
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), new Vector2(xSize, ySize), 0f, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jump.Play();
        }

        playerVariable.isJumping = !isGrounded;

        
        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), new Vector2(xSize, ySize));
    }
}
