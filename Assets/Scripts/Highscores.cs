using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    
    public Text highscores;
    
    // Start is called before the first frame update
    void Start()
    {
        
        var str = "";
        for (int i = 0; i < 5; i++)
        {
            var currentHighscore = PlayerPrefs.GetInt("HighScore" + i, 0);
            var currentUser = PlayerPrefs.GetString("HighScoreUser" + i, "");
            if (currentHighscore > 0)
            {
                str += $"{i + 1}.{currentUser}: {currentHighscore}\n";
            }
        }

        if (!PlayerPrefs.HasKey("HighScore0"))
        {
            str = "No available scores";
        }
        
        highscores.text = str;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
