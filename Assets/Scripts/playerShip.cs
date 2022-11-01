// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShip : MonoBehaviour
{
    // - Clases y variables
    public float speed = 10;
    public float rotationSpeed = 10;
    public float laserShoot;

    public GameObject bullet;
    public GameObject cannon;
    public GameObject DeathParticles;
    public AudioClip asteroidSound;

    Rigidbody2D rb;
    Animator anim;
    EdgeCollider2D colision;
    SpriteRenderer sprite;
    AudioSource audioSource;



    // !!Se ejecuta una vez
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colision = GetComponent<EdgeCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }



    // !!Se ejecuta por cada frame
    void Update()
    {
        // - Input para mover la nave en la direccion de la punta
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            Vector3 movement = new Vector3(0, vertical);
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);

            // - Animacion del propulsor y play audio
            anim.SetBool("Impulse", true);
            audioSource.Play();
        }
        else
        {
            // - Dentener animacion de propulsor y stop audio
            anim.SetBool("Impulse", false);
            audioSource.Stop();
        }
        Debug.Log(audioSource.time);


        // - Input para rotar la nave usando "Euler Angles"
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);


        // - Input para disparar el laser
        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp = Instantiate (bullet, cannon.transform.position, transform.rotation);
            Destroy (temp, laserShoot);
        }
    }



    // - Fuccion de muerte, e instancia de particulas + tiempo de respawn de la nave, y sonido de destruccion
    public void Death()
    {
        GameObject temp = Instantiate(DeathParticles, transform.position, transform.rotation);
        audioManager.Instance.PlaySound(asteroidSound);
        Destroy(temp, 4.5f);

        if (gameManager.instance.lives <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
        StartCoroutine(Respawn_Coroutine());
        }
    }



    IEnumerator Respawn_Coroutine()
    {
        // - Se desactiva la colision, el sprite y el disparo del jugador, durante 2s
        colision.enabled = false;
        sprite.enabled = false;
        laserShoot = 0;
        yield return new WaitForSeconds(2);

        // - Se resta una vida y se resetea la posicion de la nave a 0
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
        laserShoot = 1;
    }
}
