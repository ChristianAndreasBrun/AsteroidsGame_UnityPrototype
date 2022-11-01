// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float spawnTime = 60.0f;
    public float limiteX = 10;
    public float limiteY = 6;
    private float time;
    public GameObject EnemyShip;
    
    Rigidbody2D rb;



    // !!Se ejecuta por cada frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= spawnTime & gameManager.instance.score >= 1000)
        {
            Vector3 position = new Vector3(Random.Range (-limiteX, limiteX), Random.Range(-limiteY, limiteY));
            Vector3 rotation = new Vector3(0, 0, 0);
            GameObject temp = Instantiate(EnemyShip, position, Quaternion.Euler(rotation));
            time = 0;
        }
    }
}
