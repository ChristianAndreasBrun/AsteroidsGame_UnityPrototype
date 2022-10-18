// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyControl : MonoBehaviour
{
    // - Clases y variables
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    public enemyManager manager;



    // !!Se ejecuta una vez
    void Start()
    {
            // - Agrega el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();
            // - Toma una drecion aleatoria en X
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 0);
            // - Velocidad aleatoria dentro del rango establecido
        direction = direction * Random.Range(speed_min, speed_max);
            // - Añade fuerza de movimiento al objecto
        rb.AddForce(direction);
    }



    // !!Se ejecuta por cada frame
    void Update()
    {
        
    }



    // Funccion para destruir un objecto
    public void Death()
    {
       Destroy(gameObject);
    }
}
