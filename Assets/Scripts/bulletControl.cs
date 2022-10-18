// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bulletControl : MonoBehaviour
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



        // - Trigger para detectar colisiones y destruir el objecto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);


            // - Con el tag indica que objecto destruir cuando se ejecuta el trigger indicado
        if(collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<asteroidControl>().Death();
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyControl>().Death();
            Destroy(gameObject);
        }
    }
}
