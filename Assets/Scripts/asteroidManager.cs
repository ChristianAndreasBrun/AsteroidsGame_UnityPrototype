// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class asteroidManager : MonoBehaviour
{
    // - Clases y variables
    public int asteroids_min = 2;
    public int asteroids_max = 8;
    public GameObject asteroid;
    public float limiteY = 6;
    public float limiteX = 10;
    //public float limiteZ = 20;



    // !!Se ejecuta una vez
    void Start()
    {
        // - Funccion para crear un numero objectos de forma aleatoria, dentro del rango establecido
        int asteroids = Random.Range(asteroids_min, asteroids_max);

        // - Funccion FOR para instanciar objectos
        for (int i = 0; i < asteroids; i++)
        {
            //Debug.Log("Instanciado asteroid: " + i);

            // - Instancia en posiciones aleatorias dentro de los limites de la pantalla, en horizontal y vertical (X e Y)
            Vector2 position = new Vector2(Random.Range(-limiteX, limiteX), Random.Range(-limiteY, limiteY));
            // - Rota los objectos de forma aleatoria cuando se instancia
            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
            // - Guarda el objecto de forma temporal y aplica rotacion
            GameObject temp = Instantiate(asteroid, position, Quaternion.Euler(rotation));
            // - Accede al script de "asteroidControl" = "public asteroidManager manager"
            temp.GetComponent<asteroidControl>().manager = this;    // - "this" seleciona el componente actual
        }


    }




    // !!Se ejecuta por cada frame
    void Update()
    {
        
    }
}
