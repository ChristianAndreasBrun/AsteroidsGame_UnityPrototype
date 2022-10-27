// - Librerias de Unity
using UnityEngine;

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
