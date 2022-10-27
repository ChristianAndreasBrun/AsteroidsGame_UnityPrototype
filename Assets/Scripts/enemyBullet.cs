// - Librerias de Unity
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // - Clases y variables
    public float speed = 300;
   // public float lifeTime = 0.5f;
    //public float moveTime = 3f;
    Rigidbody2D rb;



    // !!Se ejecuta una vez
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * speed);
        //Destroy(gameObject, moveTime);
    }



    // !!Se ejecuta por cada frame
    void Update()
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerShip>().Death();
            Destroy(gameObject);
        }
    }

   /* void AutoDestroy()
    {
        Destroy(gameObject, lifeTime);
    }*/
}
