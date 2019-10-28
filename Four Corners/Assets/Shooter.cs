using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bull, shootPoint,pivot;
    //public GameObject gun;
    public float bulSpeed;
    public float FireRate = 0.5f;
    float timeToFire = 0;
    bool canShoot;

    PlayerScript plScript;

    void Start()
    {
        plScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        canShoot = false;
        Invoke("AllowShooting",3f);
    }

    void AllowShooting()
    {
        canShoot = true;
    }

    void Update()
    {
        if (canShoot)
        {
            Vector2 dir = (plScript.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            pivot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
        
    }

    void shoot()
    {
        //Debug.Log("Shoot Bitch!");
        Vector2 dir = (plScript.transform.position - transform.position).normalized;
        GameObject bullet = Instantiate(bull, shootPoint.transform.position, Quaternion.identity);
        //Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), bullet.GetComponent<CircleCollider2D>());
        bullet.GetComponent<Rigidbody2D>().velocity = dir * bulSpeed;
    }
}
