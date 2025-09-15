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
        // rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * player_Speed, rb.linearVelocity.y);

        horizontalMotion();

        if (Input.GetKey(KeyCode.Space) && isGrounded) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump_Height);
        }

        //  Checking for Grounded Player
        if (isGrounded)
            Debug.Log("On ground");
        if (!isGrounded)
            Debug.Log("In air");
    }


    // Player horizontal movement controller

    void horizontalMotion () 
    {
        if(Input.GetAxis("Horizontal") != 0 && isGrounded)
        {
            rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * player_Speed, rb.linearVelocity.y);
        }

    }

    // Enter trigger-based collision for ground Check.
    // If trigger hits material w/ ground tag, set bool isGrounded true.
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("GameObject1 collided with " + other.name);
            isGrounded = true;    
        }
    }

    // Exit trigger-based collision for ground Check.
    // If trigger no longer hits material w/ ground tag, set bool isGrounded false.
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

