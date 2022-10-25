// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    // - Clases y variables
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    public enemySpawner manager;
    CircleCollider2D colision;
    public GameObject bullet;
    public GameObject cannon;



    // !!Se ejecuta una vez
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colision = GetComponent<CircleCollider2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 0);
        direction = direction * Random.Range(speed_min, speed_max);
        rb.AddForce(direction);
    }



    // Funccion para destruir un objecto
    public void Death()
    {
       Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMovement>().Death();
        }
    }
}
