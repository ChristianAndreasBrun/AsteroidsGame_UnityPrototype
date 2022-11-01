// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class audioManager : MonoBehaviour
{
    public static audioManager Instance { get; private set; }
    private AudioSource audioSource;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Hay mas de un audioManager en escena!");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }



    public void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
