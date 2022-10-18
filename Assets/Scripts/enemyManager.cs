using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public GameObject spawnShip;
    public float spawnTime = 60000;
    public float time = 0;
    public float limiteX = 10;
    public float limiteY = 6;
    public float enemyLimit = 1;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //int enemyShip





       /* if(time >= spawnTime)
        {
            Vector2 position = new Vector2(Random.Range (-limiteX, limiteX), Random.Range(-limiteY, limiteY));
            Vector3 rotation = new Vector3(0, 0, 0);
            GameObject temp = Instantiate(spawnShip, position, Quaternion.Euler(rotation));
            //temp.GetComponent<enemyControl>().manager = this;
        }*/
    }
}
