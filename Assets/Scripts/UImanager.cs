// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UImanager : MonoBehaviour
{
    // - Clases y variables
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    public TextMeshProUGUI lives;
    //public int timee;
    public int scores;
    public int livees;



    // !!Se ejecuta una vez
    void Start()
    {
        
    }



    // !!Se ejecuta por cada frame
    void Update()
    {
            // - Contador del timer
        time.text = Time.time.ToString("00.00");

            // - Contador de la punctuacion
        scores = gameManager.instance.score;
        score.text = score.ToString();

            // - Contador de vidas
        livees = gameManager.instance.lives;
        lives.text = lives.ToString();
    }
}
