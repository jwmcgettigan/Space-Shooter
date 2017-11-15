using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject otherExplosion;
    public int scoreValue;

    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        } else {
            Debug.Log("Cannot find 'GameController' script.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boundary") {
            return;
        }
        if(other.tag == "Player") {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(otherExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        if(tag == "PlayerProjectile" && other.tag == "Enemy" || tag == "EnemyProjectile" && other.tag == "Player") {
            Instantiate(otherExplosion, other.transform.position, other.transform.rotation);
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
