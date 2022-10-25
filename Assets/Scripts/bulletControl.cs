// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // - Clases y variables
    public float speed = 10;
    Rigidbody2D rb;
    public float maxLifetime = 5.0f;



    // !!Se ejecuta una vez
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    public void Project(Vector2 direction)
    {
        rb.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifetime);
    }



        // - Trigger para detectar colisiones y destruir el objecto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if (collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<asteroidControl>().Death();
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyShip>().Death();
            Destroy(gameObject);
        }
    }
}
