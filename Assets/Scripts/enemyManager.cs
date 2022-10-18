// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyManager : MonoBehaviour
{
    public GameObject spawnShip;
    public float spawnTime = 3f;
    public float time = 0;
    public float limiteX = 10;
    public float limiteY = 6;
    Rigidbody2D rb;



    // !!Se ejecuta una vez
    void Start()
    {
        
    }



    // !!Se ejecuta por cada frame
    void Update()
    {
            // - Temporizador
        //time += Time.deltaTime;

        if(time >= spawnTime)
        {
            Vector2 position = new Vector2(Random.Range (-limiteX, limiteX), Random.Range(-limiteY, limiteY));
            Vector3 rotation = new Vector3(0, 0, 0);
            //GameObject temp = Instantiate(spawnShip, position, Quaternion.Euler(rotation));
            spawnTime = 0;
        }
    }
}
