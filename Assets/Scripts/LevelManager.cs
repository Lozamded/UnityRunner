using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour //Administrador del nivel
{

    public static int CoinAmount; //Canitdad de estrellas
    public bool GameOver = false; //Indicador de Game Over
    public GameObject player; // player
    public GameObject gameOverPanel; //Panel del Game Over
    public TextMeshProUGUI starsText; //Texto de conteo estrellas 
    public bool Pause = false; //indicador de pausa

    public GameObject Audio; //Administrador de sonidos

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //Escala de tiempo normal
        CoinAmount = 0; //no hay estrellas
    }


    // Update is called once per frame
    void Update()
    {
        starsText.text = "Stars: " + CoinAmount.ToString(); //Actualizar texto de estrellas
    }

    public void setGameOver() //Activar pantalla de game over y reproducir canción
    {
        GameOver = true;
        Time.timeScale = 0; //Detener el tiempo
        gameOverPanel.SetActive(true);
        Audio.GetComponent<AudioManager>().StopSong("Main"); //Detener canción del nivel
        Audio.GetComponent<AudioManager>().PlaySfx("gameover");
    }

    public void RestartLevel() //Reiniciar el nivel
    {
        GameOver = false;
        SceneManager.LoadScene("Nivel");
    }

    public void PauseGame() //Verificar pausa
    {
        switch(Pause)
        {
            case true: //Si ya esta pausado saco la pausa
                Pause = false;
                Time.timeScale = 1;
                Audio.GetComponent<AudioManager>().PlaySfx("unpause");
                Audio.GetComponent<AudioManager>().ResumeSong("Main");
                
            break;

            case false: //Si no esta pausado activo la pausa
                Pause = true;
                Time.timeScale = 0;
                Audio.GetComponent<AudioManager>().PauseSong("Main");
                Audio.GetComponent<AudioManager>().PlaySfx("pause");
            break;
        }
    }

    public void AddCoins(int number) //Añadir estrella
    {
        CoinAmount += number;
        Debug.Log(CoinAmount);
    }
}

