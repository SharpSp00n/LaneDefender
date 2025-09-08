using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }


    public TMP_Text playerLives;
    public int Lives = 3;
    public int Score = 0;
    public int HighScore = 0;
    public TMP_Text playerScore;
    public TMP_Text playerHighScore;


    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
        
    }

    public void updateScore()
    {
        Score += 1;
        playerScore.text = "Score: " + Score;
    }

    public void updateLives()
    {
        Lives -= 1;
        playerLives.text = "Lives: " + Lives;
        if (Lives == 0)
        {
            if (HighScore < Score)
            {
                HighScore = Score;
            }
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();

            SceneManager.LoadScene(0);
        }
    }

    private void UpdateUI()
    {
        
        playerHighScore.text = "High Score: " + HighScore;
        
    }

}
