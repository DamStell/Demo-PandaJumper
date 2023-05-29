using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenager : MonoBehaviour
{
    public static ScoreMenager intance;
    public Text scoreText;
    public Text highscoreText;
    int score = 0;
    int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Points: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();

    }
    private void Awake()
    {
        intance = this;
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Points: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            highscoreText.text = "Highscore: " + score.ToString();
        }

    }

  
  
    
}
