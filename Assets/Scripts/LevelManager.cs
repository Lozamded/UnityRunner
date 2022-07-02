using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public bool GameOver = false;
    public GameObject player;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGameOver()
    {
        GameOver = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        GameOver = false;
        SceneManager.LoadScene("Nivel");
    }
}

