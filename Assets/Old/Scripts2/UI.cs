using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {

    public Text scoreText, gameOverText;
    public int score;

    void Start() {
        score = 0;
        scoreText.text = "SCORE: " + score.ToString();
    }
	
	void Update() {
        
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void addScore(int add) {
        score += add;
    }

    public void enableGameOver() {
        gameOverText.enabled = true;
    }
}
