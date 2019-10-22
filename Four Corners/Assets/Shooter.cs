using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bull, shootPoint;
    //public GameObject gun;
    public float bulSpeed;
    public float FireRate = 0.5f;
    float timeToFire = 0;

    PlayerScript plScript;

    void Start()
    {
        plScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / FireRate;
            shoot();
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
