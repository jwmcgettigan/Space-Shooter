using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ship : MonoBehaviour {

    public Text scoreText, gameOverText;
    public int score;

    public bool friendly;
    public float speed = 30f;
    private Rigidbody2D rb;
    public Vector2 velocity;
    private float hMove, vMove;
    public int lives, motionType;

    private float RotateSpeed = 2f, Radius, angle;
    private Vector2 centre;
    private Vector3 pos, axis;
    //private UI display;

    void Start() {
        //display = new UI();
        if (friendly) {
            rb = GetComponent<Rigidbody2D>();
            lives = 3;
        } else {
            GameObject[] boundaries = GameObject.FindGameObjectsWithTag("boundary");
            for (int i = 0; i < 4; i++) {
                Physics2D.IgnoreCollision(boundaries[i].GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            }
            centre = transform.position;
            pos = transform.position;
            axis = transform.right;
            random();
            Destroy(gameObject, 10.0f);
        }
    }

    void random() {
        System.Random rnd = new System.Random();
        motionType = rnd.Next(1, 4);
    }

    void Update(){
        if (!friendly) {
            move();
        }
    }
	
	void FixedUpdate () {
        if (friendly) {
            move();
        }
	}

    private void move() {
        if (friendly) {
            hMove = Input.GetAxis("Horizontal") * speed;
            vMove = Input.GetAxis("Vertical") * speed;
            rb.MovePosition(rb.position + (new Vector2(hMove, vMove)) * Time.fixedDeltaTime);
        } else {
            if (motionType == 1) {
                clockwiseCircularMotion();
            } else if (motionType == 2) {
                anticlockwiseCircularMotion();
            } else if (motionType == 3) {
                SMotion();
            }
        }
    }

    private void respawn() { //player
        Instantiate(gameObject, new Vector2(0f, -20f), transform.rotation);
    }
    
    private void OnCollisionEnter2D(Collision2D col) {
        if(friendly && col.gameObject.CompareTag("enemyShip") || !friendly && col.gameObject.CompareTag("playerShip")) {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (friendly) {
            if (col.gameObject.CompareTag("enemyProjectile")) {
                Destroy(gameObject);
                Destroy(col.gameObject);
                if (lives > 0) {
                    lives--;
                    //respawn();
                } else {
                    //display.enableGameOver();
                    //gameOverText.enabled = true;
                }
            }
        } else if (col.gameObject.CompareTag("playerProjectile")) {
            Destroy(gameObject);
            Destroy(col.gameObject);
            //display.addScore(100);
            //score += 100;
            //scoreText.text = "SCORE: " + score.ToString();
        }
    }



    private void clockwiseCircularMotion() {
        Radius = 40f;
        angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;
    }

    private void anticlockwiseCircularMotion() {
        Radius = 40f;
        angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;
        transform.position = centre + offset;
    }

    private void SMotion() {
        float MoveSpeed = 13.0f;
        float frequency = 5.0f;
        float magnitude = 10f;
        pos -= transform.up * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
