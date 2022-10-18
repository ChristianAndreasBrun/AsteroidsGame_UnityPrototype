using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public float limitX = 10;
    public float limitY = 6;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
