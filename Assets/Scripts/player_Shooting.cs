using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Shooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLife;

    Vector2 pointingDirection;
    float thetaVal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        thetaVal = Mathf.Atan2(pointingDirection.y,pointingDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0f, 0f, thetaVal);

        fireBullet();
    }

    void fireBullet() 
    {
        if (Input.GetMouseButtonDown(0))
        { 
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0,0,thetaVal);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
            Destroy(bulletClone, bulletLife);
        }
    }
}
