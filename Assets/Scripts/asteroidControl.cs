using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class asteroidControl : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    public asteroidManager manager;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction = direction * Random.Range(speed_min, speed_max);
        //Debug.Log(direction);
        rb.AddForce(direction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Funccion para destruir un objecto
    public void Death()
    {
        GameObject temp1 = Instantiate(manager.asteroid, transform.position, transform.rotation);
        temp1.GetComponent<asteroidControl>().manager = manager;
        temp1.transform.localScale = transform.localScale * 0.5f;

        GameObject temp2 = Instantiate(manager.asteroid, transform.position, transform.rotation);
        temp2.GetComponent<asteroidControl>().manager = manager;
        temp2.transform.localScale = transform.localScale * 0.5f;

        Destroy(gameObject);
    }

    // Trigger para detectar colisiones y destruir el objecto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMovement>().Death();
            //Destroy(gameObject);
        }
    }
}
