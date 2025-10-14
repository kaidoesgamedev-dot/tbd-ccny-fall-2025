using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_Shooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLife;

    Vector2 pointingDirection;
    float thetaVal;

    public warpPlayer currentProjectile;

    // points the gameobject to the cursor
    // grabs an angle for rotational point
    // rotates firePoint object
    void Update()
    {
        pointingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        thetaVal = Mathf.Atan2(pointingDirection.y,pointingDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0f, 0f, thetaVal);

        fireBullet();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Warping to " + currentProjectile);
            warpBullet();
        }
    }

    // checks for left click and if there's no bullet
    // if true, instantate bulletClone at firepoint position
    // 
    void fireBullet() 
    {
        if (Input.GetMouseButtonDown(0) && currentProjectile == null)
        { 
            GameObject bulletClone = Instantiate(bullet);

            currentProjectile = bulletClone.GetComponent<warpPlayer>();

            if(currentProjectile != null ) 
            {
                currentProjectile.setOwner(this.gameObject);
            }

            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0,0,thetaVal);

            bulletClone.GetComponent<Rigidbody2D>().linearVelocity = firePoint.right * bulletSpeed;
            Destroy(bulletClone, bulletLife);
        }
    }

    void warpBullet()
    {
        if (currentProjectile != null)
        {
            transform.position = currentProjectile.transform.position;
            Destroy(currentProjectile.gameObject);
        }
    }
}
