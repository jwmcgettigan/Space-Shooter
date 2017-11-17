using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public Vector2 spawnValues;
    public int enemyCount;

    public float spawnWait, startWait, waveWait;

    public Text scoreText, restartText, gameOverText;
    private int score;

    private bool gameOver, restart;

    void Start() {
        gameOver = false;
        restart = false;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update() {
        if (restart) {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves() {
        while (true) {
            yield return new WaitForSeconds(startWait);
            float spawnX = Random.Range(-spawnValues.x, spawnValues.x);
            for (int i = 0; i < enemyCount; i++) {
                Vector2 spawnPosition = new Vector2(spawnX, spawnValues.y);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnWait);

            if (gameOver) {
                invertEnabled(restartText);
                InvokeRepeating("flashingRestart", 0.5f, 0.5f);
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore() {
        scoreText.text = "SCORE: " + score;
    }

    public void GameOver() {
        invertEnabled(gameOverText);
        gameOver = true;
    }

    public void flashingRestart() {
        invertEnabled(restartText);
    }

    public void invertEnabled(Text text) {
        text.enabled = !text.enabled;
    }
}
