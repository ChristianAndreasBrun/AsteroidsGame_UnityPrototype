// - Librerias de Unity
using UnityEngine;

public class enemyShip : MonoBehaviour
{
    // - Clases y variables
    public float minSpeed;
    public float maxSpeed;
    public GameObject bullet;
    public GameObject laserPos;
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


    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            /*timer = 0;
            shoot();*/

            Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(bullet, laserPos.transform.position, Quaternion.Euler(rotacion));
            Destroy(temp, 5.0f);
            timer = 0;
        }
    }


   /* void shoot()
    {
        Instantiate(bullet, laserPos.position, Quaternion.identity);
    }*/


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
