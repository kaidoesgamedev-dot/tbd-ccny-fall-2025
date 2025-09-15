using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class player_Controls : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float player_Speed;
    [SerializeField] private float jump_Height;


    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * player_Speed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isGrounded) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_Height);
        }

        //  Checking for Grounded Player
        if (isGrounded)
            Debug.Log("On ground");
        if (!isGrounded)
            Debug.Log("In air");
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;    
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

