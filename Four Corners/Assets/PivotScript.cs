using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    PlayerScript plScript;
    // Start is called before the first frame update
    void Start()
    {
        plScript = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            plScript.wallHit = true;
        }
    }

    /*void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            plScript.wallHit = true;
        }
    }*/

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            plScript.wallHit = false;
        }
    }
}
