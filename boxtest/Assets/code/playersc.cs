using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playersc : MonoBehaviour
{
    public float speed = 5f; // speed of movement
    public float jumpForce = 5f; // force of the jump
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the Rigidbody2D component
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // get horizontal input axis value
        bool jumpInput = Input.GetButtonDown("Jump"); // check if jump input button is pressed

        // add horizontal velocity to player
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // add vertical force to player when jump button is pressed and player is grounded
        if (jumpInput && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private bool IsGrounded()
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(circleCollider.bounds.center, circleCollider.radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                return true;
            }
        }
        return false;
    }
}