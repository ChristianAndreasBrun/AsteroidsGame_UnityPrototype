// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShip : MonoBehaviour
{
    // - Clases y variables
    public float minSpeed;
    public float maxSpeed;
    private float timer;
    public GameObject bullet;
    public GameObject laserPos;
    public AudioClip asteroidSound;

    CircleCollider2D colision;
    Rigidbody2D rb;



    // !!Se ejecuta una vez
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colision = GetComponent<CircleCollider2D>();

        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 0);
        direction = direction * Random.Range(minSpeed, maxSpeed);
        rb.AddForce(direction);
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(bullet, laserPos.transform.position, Quaternion.Euler(rotacion));
            Destroy(temp, 0.8f);
            timer = 0;
        }
    }



    public void Death()
    {
        gameManager.instance.score += 200;
        audioManager.Instance.PlaySound(asteroidSound);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerShip>().Death();
        }
    }
}
