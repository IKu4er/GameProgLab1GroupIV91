using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    public float horizontalSpeed;
    float speedX;
    public float verticalSpeed;
    float speedY;
    public float verticalImpulse;
    Rigidbody2D rb;
    bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed; 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            speedY = verticalSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            speedY = -verticalSpeed;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, speedY, 0);
        speedX = 0;
        speedY = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}
