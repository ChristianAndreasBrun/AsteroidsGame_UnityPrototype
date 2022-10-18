using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed = 10;
    public float rotationSpeed = 10;
    public GameObject bullet;
    public GameObject cannon;


    // Se ejecuta una vez
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Se ejecuta por cada frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            Vector3 movement = new Vector3(0, vertical);
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulse", true);
        }
        else
        {
            anim.SetBool("Impulse", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);


        // Deeclarar boton de accion y tiempo de muerte de la bala
        if (Input.GetButtonDown("Jump")) 
        {
            
            GameObject temp = Instantiate (bullet, cannon.transform.position, transform.rotation);
            Destroy (temp, 1.5f);
        }

    }

    // Fuccion de muerte
    public void Death()
    {
        //Destroy(gameObject);
    }
}
