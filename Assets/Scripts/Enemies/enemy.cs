using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour {

    public UI content;

    // Use this for initialization
    void Start () {
        GameObject[] boundaries = GameObject.FindGameObjectsWithTag("boundary");
        for(int i = 0; i < 4; i++) {
            Physics2D.IgnoreCollision(boundaries[i].GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
        Destroy(gameObject, 10.0f);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("enemyShip")) {
            float magnitude = 100f;
            Vector2 force = transform.position - col.transform.position;
            force.Normalize();
            gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);
        }
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("playerProjectile")) {
            Destroy(gameObject);
            Destroy(col.gameObject);
            //GameObject.Find("Enemy Spawn").GetComponent<UI>().score += 100;
            //score += 100;
            content.addScore(100);
        }
    }
}
