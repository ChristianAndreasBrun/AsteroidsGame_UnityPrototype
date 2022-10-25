// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    // Funciones
    public float limitX = 10;
    public float limitY = 6;



    // !!Se ejecuta por cada frame
    void Update()
    {
        if (transform.position.y > limitY)
        {
            transform.position = new Vector3(transform.position.x, -limitY);
            //Debug.Log("Estoy por arriba");
        }
        if (transform.position.y < -limitY)
        {
            transform.position = new Vector3(transform.position.x, limitY);
            //Debug.Log("Estoy por debajo");
        }


        if (transform.position.x > limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y);
            //Debug.Log("Estoy por la izquierda");
        }
        if (transform.position.x < -limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y);
            //Debug.Log("Estoy por por la derecha");
        }
    }
}
