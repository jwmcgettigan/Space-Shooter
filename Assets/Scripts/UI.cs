using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {

    public Text scoreText, gameOverText;
    public int score;

    // Use this for initialization
    void Start () {
        score = 0;
        scoreText.text = "SCORE: " + score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addScore(int add) {
        score += add;
    }

    public void enableGameOver() {
        gameOverText.enabled = true;
    }
}
