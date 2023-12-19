using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;

    private Rigidbody2D rb;
    public LayerMask groundMask;

    public Transform groundCheck;

    public bool canJump = true;
    public float jumpValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if(jumpValue == 0.0 && isGrounded )
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundMask);
        
        if (Input.GetKeyDown("space") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 0.1f;
        }

        if(jumpValue > 20f && isGrounded)
        {
            float tmpx = moveInput * walkSpeed;
            float tmpy = jumpValue;
            rb.velocity = new Vector2(tmpx, tmpy);
            Invoke("ResetJump", 0.1f);
        }

        if (Input.GetKeyUp("space"))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0f;
            }
            canJump = true;
        }
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheck.position, 0.3f);
    }
}
