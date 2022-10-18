// - Librerias de Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // - Clases y variables
    public static gameManager instance;
    public int time;
    public int score;
    public int lives;



    // !! Se ejecuta antes del Start
    private void Awake()
    {
        instance = this;
    }
}
