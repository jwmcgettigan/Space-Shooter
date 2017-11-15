using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour {

    public bool friendly;
    public GameObject projectile;
    public float speed = 50f;
    public float fireRate = 0.5f;
    private float lastShot = 0f;

    // Use this for initialization
    void Start () {
        GameObject[] boundaries = GameObject.FindGameObjectsWithTag("boundary");
        for (int i = 0; i < 4; i++) {
            Physics2D.IgnoreCollision(boundaries[i].GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (friendly) {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 0")) {
                launch();
            }
        } else {
            launch();
        }
	}

    private void launch() {
        Vector2 pos = transform.position, dir;
        float nudge;
        if (friendly) {
            dir = Vector2.up;
            nudge = 3f;
        } else {
            dir = Vector2.down;
            nudge = -3f;
        }
        if (Time.time > fireRate + lastShot && pos.y < GameObject.Find("Top Boundary").transform.position.y) {
            GameObject shot;
            if(tag == "Player") {
                shot = Instantiate(projectile, new Vector2(pos.x, pos.y + nudge), transform.rotation);
            } else {
                shot = Instantiate(projectile, new Vector2(pos.x, pos.y - nudge), Quaternion.Euler(0f, 180f, 0f));
            }

            shot.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(dir * speed);
            lastShot = Time.time;
            Destroy(shot, 3.0f);
        }
    }
}
