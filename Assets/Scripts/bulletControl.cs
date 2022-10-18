using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bulletControl : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Trigger para detectar colisiones y destruir el objecto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
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
