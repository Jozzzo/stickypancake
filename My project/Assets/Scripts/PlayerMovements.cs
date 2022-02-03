using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Object References")]
    private Rigidbody2D rb;
    private float ScreenWidth;

    public float speed;
    public float jump;
    public float move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScreenWidth = Screen.width;
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Jump(touch);
        }
    }

    public void Jump(Touch touch)
    {
        if (touch.position.x > ScreenWidth / 2)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if (touch.position.x < ScreenWidth / 2)
        {
            rb.velocity = new Vector2(0 - move * speed, rb.velocity.y);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
}
