// - Librerias de Unity
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    // - Clases y variables
    private GameObject enemy;
    public float speed = 10;
    public float lifeTime = 0.5f;
    public float moveTime = 3f;
    Rigidbody2D rb;



    // !!Se ejecuta una vez
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Player");

        if (enemy.transform.localScale.x > 0)
        {
            speed = -speed;
        }

        //rb.AddForce(transform.position * speed);
        Destroy(gameObject, moveTime);
    }



    // !!Se ejecuta por cada frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<enemyShip>().Death();
            Destroy(gameObject);
        }
    }

    void AutoDestroy()
    {
        Destroy(gameObject, lifeTime);
    }
}
