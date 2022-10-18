using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class asteroidManager : MonoBehaviour
{
    public int asteroids_min = 2;
    public int asteroids_max = 8;
    public float limiteY = 6;
    public float limiteX = 10;
    /*public float limitZ = 10;*/
    public GameObject asteroid;

    // Start is called before the first frame update
    void Start()
    {
        int asteroids = Random.Range(asteroids_min, asteroids_max);

        for (int i = 0; i < asteroids; i++)
        {
            //Debug.Log("Instanciado asteroid: " + i);
            Vector2 position = new Vector2(Random.Range(-limiteX, limiteX), Random.Range(-limiteY, limiteY));
            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(asteroid, position, Quaternion.Euler(rotation));
            temp.GetComponent<asteroidControl>().manager = this;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
