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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheck.position, 0.3f);
    }
}
