using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyControl : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    public enemyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 0);
        direction = direction * Random.Range(speed_min, speed_max);
        rb.AddForce(direction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Funccion para destruir un objecto
    public void Death()
    {
       Destroy(gameObject);
    }
}
