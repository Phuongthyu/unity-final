using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool Jump;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h_move = Input.GetAxis("Player2_Horizontal");

        rb.velocity = new Vector2(h_move * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Jump && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Đặt vận tốc y về 0 trước khi nhảy
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrian")
        {
            Jump = true;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrian")
        {
            Jump = false;
            isGrounded = false;
        }
    }
}
