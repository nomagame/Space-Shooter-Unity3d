using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public float waveWait = 2.0f;
    public float startWait = 1.0f;
    public float spawnWait;
    public int hazardCound;
    public GameObject hazard;
    public Vector3 spawnValues;
    private Vector3 spawnPosition = Vector3.zero;
    public Quaternion spawnRotation ;
    public Text gameOverText;
    private bool gameOver;
    public Text restartText;
    private bool restart;

    IEnumerator SpawnWaves()
    {
        if (gameOver)
        {        
            yield break;
        }
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCound; i++)
            {
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                spawnPosition.z = spawnValues.z;
                spawnRotation = new Quaternion(0,0,0,0);
                Instantiate(hazard, spawnPosition,spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void Start()
    {
        restartText.text = " ";
        restart = false;
        gameOverText.text = " ";
        gameOver = false;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            }
        }
    }

    public void AddSource(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        
    }

    void UpdateScore()
    {
        scoreText.text = "得分:" + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over";
        restartText.text = "Press 'R' Restart Game";
        restart = true;
    }
}
