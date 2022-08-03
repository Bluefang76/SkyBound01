using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeps : MonoBehaviour
{


    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;


    public float currentScore;
    public float highScore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);

            
        }

        currentScoreText.text = "Current Score: " + currentScore;
        highScoreText.text = "High Score: " + highScore;
    }
}
