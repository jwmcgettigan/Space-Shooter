using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {

    public GameObject blast;
    public float speed = 50f;
    public float fireRate = 0.25f;
    private float lastFire = 0f;
    private Vector2 pos, dir;
    public Sprite[] sprites = new Sprite[3];

    void Update () {
		if(Time.time > fireRate + lastFire) {
            pos = transform.position;
            GameObject clone = null;
            if (tag == "Player" && Input.GetButton("Jump") || Input.GetButton("Fire1")) {
                clone = Instantiate(blast, new Vector2(pos.x, pos.y + 3f), transform.rotation);
                randomizeSprite(clone);
                clone.tag = "PlayerProjectile";
                dir = Vector2.up;
            }
            if (tag == "Enemy" && transform.position.y > -40) {
                clone = Instantiate(blast, new Vector2(pos.x, pos.y - 3f), Quaternion.Euler(180f, 0f, 0f));
                clone.tag = "EnemyProjectile";
                dir = Vector2.down;
            }
            try {
                clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(dir * speed);
            } catch(Exception ex) {
                //An exception is thrown here but I want to ignore it.
            }
            lastFire = Time.time;
        }
	}

    void randomizeSprite(GameObject clone) {
        clone.GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, 2)];
    }
}
//Instantiate(blast, new Vector2(pos.x, pos.y + 3f), transform.rotation).GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * speed);