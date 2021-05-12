using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Spawn Asteroid")]
    public GameObject[] asteroids;
    public Vector3 spawnValues;
    public int asteroidAcount;
    public float spawnWait;
    public float starWait;
    public float waveWait;

    [Header("Score")]
    private int score;
    public Text scoreText;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(starWait);
        while (true)
        {
            for (int i = 0; i < asteroidAcount; i++)
            {
                GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(asteroid, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
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
        if(score == 100)
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}
