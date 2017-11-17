using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject[] explosions = new GameObject[11];
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
        if( tag != "PlayerProjectile" && other.tag == "Player") {
            if (tag != "EnemyProjectile") {
                Instantiate(explosions[Random.Range(0, 11)], transform.position, transform.rotation);
            }
            Instantiate(explosions[Random.Range(0, 11)], other.transform.position, other.transform.rotation);
            gameController.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (tag == "PlayerProjectile" && other.tag == "Enemy") {
            Instantiate(explosions[Random.Range(0, 11)], other.transform.position, other.transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
