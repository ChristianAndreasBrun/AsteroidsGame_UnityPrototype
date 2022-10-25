using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidControl : MonoBehaviour
{
    // - Clases y variables
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    public asteroidManager manager;



    // !!Se ejecuta una vez
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction = direction * Random.Range(speed_min, speed_max);
        //Debug.Log(direction);

        rb.AddForce(direction);
        manager.asteroids += 1;
    }



    // - Funccion para dividir un objecto en 2 de menor escala, cuando es destruido
    public void Death()
    {

        if (transform.localScale.x > 0.25f)
        {
            GameObject temp1 = Instantiate(manager.asteroid, transform.position, transform.rotation);
            temp1.GetComponent<asteroidControl>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;

            GameObject temp2 = Instantiate(manager.asteroid, transform.position, transform.rotation);
            temp2.GetComponent<asteroidControl>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;

            gameManager.instance.score += 100;

        }
        manager.asteroids -= 1;
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
