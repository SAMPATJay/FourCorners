using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject pivot;
    public GameObject dirPoint;
    public GameObject center;
    public float pivotSpeed;
    public float pivotRange;
    public float playerSpeed;
    public bool canRotate;
    public bool wallHit;
    public bool canMove;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startRotate();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canRotate = false;
            if (canMove)
            {
                move();
                Vector2 dir = (dirPoint.transform.position - transform.position).normalized;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                pivot.transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
            }
        }
    }

    void FixedUpdate()
    {
        if (canRotate)
        {
            rotate();
        }
    }

    void rotate()
    {
        pivot.SetActive(true);
        pivot.transform.Rotate(0, 0, Time.deltaTime * pivotSpeed);
        if (wallHit)
        {
            pivotSpeed *= -1;
            wallHit = false;
        }
    }

    void move()
    {
        Vector2 dir = (dirPoint.transform.position- transform.position).normalized;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.velocity = dir * playerSpeed;
        canMove = false;
        

        pivot.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canRotate)
        {
            if (collision.gameObject.tag == "Wall")
            {
                
                rb.velocity = Vector2.zero;
                Invoke("startRotate", 0.2f);
            }
        }
    }

    void startRotate()
    {
        canRotate = true;
        canMove = true;
    }

}
