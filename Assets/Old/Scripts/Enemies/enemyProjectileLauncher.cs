using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectileLauncher : MonoBehaviour {

    public GameObject projectile;
    public float speed = 50f;
    public float fireRate = 0.2f;
    private float lastShot = 0f;

    void Start() {
        GameObject[] boundaries = GameObject.FindGameObjectsWithTag("boundary");
        for (int i = 0; i < 4; i++) {
            Physics2D.IgnoreCollision(boundaries[i].GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
    }

    // Use something other than fixed update so that the frequency can be changed by power ups.
    void Update() {
        fire();
    }

    private void fire() {
        Vector2 pos = transform.position;
        if (Time.time > fireRate + lastShot && pos.y < GameObject.Find("Top Boundary").transform.position.y) {
            GameObject bullet = (GameObject)Instantiate(projectile, new Vector2(pos.x, pos.y - 3f), transform.rotation);

            bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.down * speed);
            lastShot = Time.time;
            Destroy(bullet, 3.0f);
        }
    }
}
