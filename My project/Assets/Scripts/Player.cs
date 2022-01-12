using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ms = 6;
    
    private Rigidbody2D rb;
    private Vector3 velocityToUpdate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocityToUpdate = new Vector3(0f, 0f, 0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * ms * Time.deltaTime);
            GetComponent<Rigidbody2D>().velocity = velocityToUpdate; 
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * ms * Time.deltaTime);
            GetComponent<Rigidbody2D>().velocity = velocityToUpdate;
        }
        
    }
}
