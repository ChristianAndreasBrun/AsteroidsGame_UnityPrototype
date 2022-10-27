// - Librerias de Unity
using UnityEngine;

public class enemyShip : MonoBehaviour
{
    // - Clases y variables
    public float minSpeed;
    public float maxSpeed;
    public GameObject bullet;
    public Transform laserPos;
    private float timer;
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


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            timer = 0;
            shoot();
        }
    }


    void shoot()
    {
        Instantiate(bullet, laserPos.position, Quaternion.identity);
    }


    // - Funccion para destruir un objecto
    public void Death()
    {
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
