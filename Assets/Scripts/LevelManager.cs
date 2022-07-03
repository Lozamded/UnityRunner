using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static int CoinAmount;
    public bool GameOver = false;
    public GameObject player;
    public GameObject gameOverPanel;
    public TextMeshProUGUI starsText;
    public bool Pause = false;

    public GameObject Audio;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        CoinAmount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        starsText.text = "Stars: " + CoinAmount.ToString();
    }

    public void setGameOver()
    {
        GameOver = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        Audio.GetComponent<AudioManager>().StopSong("Main");
        Audio.GetComponent<AudioManager>().PlaySfx("gameover");
    }

    public void RestartLevel()
    {
        GameOver = false;
        SceneManager.LoadScene("Nivel");
    }

    public void PauseGame()
    {
        switch(Pause)
        {
            case true:
                Pause = false;
                Time.timeScale = 1;
                Audio.GetComponent<AudioManager>().PlaySfx("unpause");
                Audio.GetComponent<AudioManager>().ResumeSong("Main");
                
            break;

            case false:
                Pause = true;
                Time.timeScale = 0;
                Audio.GetComponent<AudioManager>().PauseSong("Main");
                Audio.GetComponent<AudioManager>().PlaySfx("pause");
            break;
        }
    }

    public void AddCoins(int number)
    {
        CoinAmount += number;
        Debug.Log(CoinAmount);
    }
}

