// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShip : MonoBehaviour
{
    // - Clases y variables
    Rigidbody2D rb;
    Animator anim;
    EdgeCollider2D colision;
    SpriteRenderer sprite;
    public float speed = 10;
    public float rotationSpeed = 10;
    public GameObject bullet;
    public GameObject cannon;
    public GameObject DeathParticles;
    public AudioClip thrustSound;



    // !!Se ejecuta una vez
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colision = GetComponent<EdgeCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }



    // !!Se ejecuta por cada frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            Vector3 movement = new Vector3(0, vertical);
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            audioManager.Instance.PlaySound(thrustSound);
            anim.SetBool("Impulse", true);
        }
        else
        {
            anim.SetBool("Impulse", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp = Instantiate (bullet, cannon.transform.position, transform.rotation);
            Destroy (temp, 1.5f);
        }
    }



    // - Fuccion de muerte
    public void Death()
    {
        GameObject temp = Instantiate(DeathParticles, transform.position, transform.rotation);
        Destroy(temp, 2.5f);

        if (gameManager.instance.lives <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        else
        {
        StartCoroutine(Respawn_Coroutine());
        }
    }



    IEnumerator Respawn_Coroutine()
    {
        colision.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(2);

        gameManager.instance.lives -= 1;
        rb.velocity = new Vector2 (0, 0);
        transform.position = new Vector3(0, 0, 0);

            // - Animacion de imortalidad al respawnear
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        colision.enabled = true;
    }
}
