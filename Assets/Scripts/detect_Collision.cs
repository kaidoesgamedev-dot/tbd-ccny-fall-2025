using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_Collision : MonoBehaviour
{

    public GameObject bullet;

    // Logic to determine if the bullet has collided with
    // the ground or wall to immediately destroy
    // instantiated target
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(bullet);
        }
    }
}
