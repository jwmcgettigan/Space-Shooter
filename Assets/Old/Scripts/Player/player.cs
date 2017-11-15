using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class player : MonoBehaviour {

    public float speed = 30f;
    public Rigidbody2D rb;
    public Vector2 velocity;
    private float hMove, vMove;
    public UI content;

    private int lives;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        lives = 3;
    }

    void FixedUpdate()
    {
        move();
    }

    private void move(){
		hMove = Input.GetAxis("Horizontal") * speed;
        vMove = Input.GetAxis("Vertical") * speed;
        rb.MovePosition(rb.position + (new Vector2(hMove, vMove)) * Time.fixedDeltaTime);
    }

    private void respawn(){
        Instantiate(gameObject, new Vector2(0f, -20f), transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("enemyProjectile")) {
            Destroy(gameObject);
            Destroy(col.gameObject);
            //lose life / game over
            if(lives > 0) {
                lives--;
                respawn();
            } else {
                //GameObject.Find("Enemy Spawn").GetComponent<UI>().gameOverText.enabled = true;
                //gameOverText.enabled = true;
                //GameObject
                content.enableGameOver();
            }
        }
    }
}
