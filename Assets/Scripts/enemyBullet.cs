using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    // - Clases y variables
    public float speed = 10;
    Rigidbody2D rb;



    // !!Se ejecuta una vez
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    // !!Se ejecuta por cada frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyShip>().Death();
            Destroy(gameObject);
        }
    }
}
