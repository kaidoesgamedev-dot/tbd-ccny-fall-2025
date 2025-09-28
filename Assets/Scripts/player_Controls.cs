using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_Controls : MonoBehaviour
{

    public Rigidbody2D rb;

    public Transform destination;
    [SerializeField] private float player_Speed;
    [SerializeField] private float jump_Height;
    [SerializeField] private float air_Speed;
    private float air_Control;


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

        //horizontalMotion();

        Debug.Log(air_Control);
        
        if(isGrounded) 
        {
            horizontalMotion();
        }
        if (!isGrounded && air_Control == 1)
        {

            horizontalMotion();
        }



        if (Input.GetKey(KeyCode.Space) && isGrounded) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump_Height);
            air_Control = 1;
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
        if(Input.GetAxis("Horizontal") != 0 && !isGrounded)
        {
            rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * air_Speed, rb.linearVelocity.y);
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
            air_Control = 0;
        }

        if (other.gameObject.CompareTag("gameWin"))
        {
            SceneManager.LoadSceneAsync(3);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gameOver"))
        {
            SceneManager.LoadSceneAsync(1);
        }

    }


}

