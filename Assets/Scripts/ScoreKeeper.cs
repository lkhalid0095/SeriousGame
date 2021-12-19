using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    public Text scoreText;
    public Text playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
        InvokeRepeating("Tick", 0,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            CancelInvoke();
        }
    }

    private void Tick()
    {
        PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") - 1);
        scoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
    }
    
    public void SaveScore()
    {
        var score = Int32.Parse(scoreText.text);
        var name = playerName.text;
        
        for (int i = 0; i < 5; i++)
        {
            var currentHighscore = PlayerPrefs.GetInt("HighScore" + i, 0);
            var currentUser = PlayerPrefs.GetString("HighScoreUser" + i, "");
            if (currentHighscore == 0)
            {
                PlayerPrefs.SetInt("HighScore" + i, score);
                PlayerPrefs.SetString("HighScoreUser" + i, name);
                SceneManager.LoadScene("Main Menu");
                return;
            } else if (currentHighscore < score)
            {
                PlayerPrefs.SetInt("HighScore" + i, score);
                PlayerPrefs.SetString("HighScoreUser" + i, name);
                score = currentHighscore;
                name = currentUser;
            }
        }
        SceneManager.LoadScene("Main Menu");

    }
    
}
