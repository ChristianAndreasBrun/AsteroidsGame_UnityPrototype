// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject spawnShip;
    public float spawnTime = 60.0f;
    public float time = 0;
    public float limiteX = 10;
    public float limiteY = 6;
    Rigidbody2D rb;



    // !!Se ejecuta por cada frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= spawnTime)
        {
            Vector3 position = new Vector3(Random.Range (-limiteX, limiteX), Random.Range(-limiteY, limiteY));
            Vector3 rotation = new Vector3(0, 0, 0);
            GameObject temp = Instantiate(spawnShip, position, Quaternion.Euler(rotation));
            time = 0;
        }
    }
}
