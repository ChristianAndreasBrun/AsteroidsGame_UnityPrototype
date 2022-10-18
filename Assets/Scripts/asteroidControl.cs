// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        // - Toma una drecion aleatoria en X e Y
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        // - Velocidad aleatoria dentro del rango establecido
        direction = direction * Random.Range(speed_min, speed_max);
        //Debug.Log(direction);

        // - Añade fuerza al objecto
        rb.AddForce(direction);
    }




    // !!Se ejecuta por cada frame
    void Update()
    {
        
    }




    // - Funccion para dividir un objecto en 2 de menor escala, cuando es destruido
    public void Death()
    {
        // - Instacia un objecto a menor escala cuando se destruye el primero
        GameObject temp1 = Instantiate(manager.asteroid, transform.position, transform.rotation);
        // - Instancia otro asteroide
        temp1.GetComponent<asteroidControl>().manager = manager;
        // - Escala el objecto, a la mitad del tamaño original
        temp1.transform.localScale = transform.localScale * 0.5f;

        GameObject temp2 = Instantiate(manager.asteroid, transform.position, transform.rotation);
        temp2.GetComponent<asteroidControl>().manager = manager;
        temp2.transform.localScale = transform.localScale * 0.5f;

        // - Destruye el primer objecto antes de dividir
        Destroy(gameObject);
    }




    // - Trigger para detectar las colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.tag == "Player")
        {
            // - Cuando colisiona, se destruye
            collision.gameObject.GetComponent<playerMovement>().Death();
            //Destroy(gameObject);
        }
    }
}
