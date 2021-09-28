using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    private int score;
    public Text scoreText;

    void Start()
    {
        score = 0;
        UpdateScore();
    }


    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        if(score == 10)
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}
