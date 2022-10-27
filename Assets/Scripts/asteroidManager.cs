// - Librerias de Unity
using UnityEngine;

public class asteroidManager : MonoBehaviour
{
    // - Clases y variables
    public int asteroids_min = 2;
    public int asteroids_max = 8;
    public int asteroids;
    public float limiteX = 10;
    public float limiteY = 6;
    public GameObject asteroid;



    // !!Se ejecuta una vez
    void Start()
    {
        createAsteroids();
    }



    // !!Se ejecuta por cada frame
    void Update()
    {
        if(asteroids <= 0)
        {
                // - Suma objectos
            asteroids_min += 2;
            asteroids_max += 2;
            createAsteroids();
        }
    }



    void createAsteroids()
    {
        int asteroids = Random.Range(asteroids_min, asteroids_max);

        for (int i = 0; i < asteroids; i++)
        {

            Vector3 posicion = new Vector3(Random.Range(-limiteX, limiteX), Random.Range(-limiteY, limiteY));

            while (Vector3.Distance(posicion, new Vector3(0, 0, 0)) < 2)
            {
                posicion = new Vector3(Random.Range(-limiteX, limiteX), Random.Range(-limiteY, limiteY));
            }

            Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(asteroid, posicion, Quaternion.Euler(rotacion));
            temp.GetComponent<asteroidControl>().manager = this;
        }
    }
}
