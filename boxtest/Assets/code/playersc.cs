using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playersc : MonoBehaviour
{
    public float speed = 5f; // speed of movement
    public float jumpForce = 5f; // force of the jump
    private Rigidbody2D rb;
    private bool isGrounded = false;

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
        if (jumpInput && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}