using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ms = 6;

    private Rigidbody2D rb;
    private Vector3 velocityToUpdate;
    private float ScreenWidth;
    private Touch touch;
    private bool previousWasTouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocityToUpdate = new Vector3(0f, 0f, 0f);
        ScreenWidth = Screen.width;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        bool isTouching = Input.touchCount > 0;
        if (isTouching && !previousWasTouching)
        {
                if (touch.position.x > ScreenWidth / 2)
                {
                    transform.Translate(Vector3.up * ms * Time.deltaTime);
                    GetComponent<Rigidbody2D>().velocity = velocityToUpdate;
                }

                if (touch.position.x < ScreenWidth / 2)
                {
                    transform.Translate(Vector3.down * ms * Time.deltaTime);
                    GetComponent<Rigidbody2D>().velocity = velocityToUpdate;
                    previousWasTouching = isTouching;
                }
        }
    }
}