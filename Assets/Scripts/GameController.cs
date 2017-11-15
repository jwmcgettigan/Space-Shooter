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
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update() {
        if (restart) {
            if (Input.GetKey(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves() {
        while (true) {
            yield return new WaitForSeconds(startWait);
            for(int i = 0; i < enemyCount; i++) {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
            }
            yield return new WaitForSeconds(spawnWait);

            if (gameOver) {
                restartText.text = "Press any key to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "SCORE: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
