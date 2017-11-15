using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {

    public GameObject blast;
    public float speed = 50f;
    public float fireRate = 0.25f;
    private float lastFire = 0f;
    private Vector2 pos;

    void Update () {
		if(Time.time > fireRate + lastFire) {
            pos = transform.position;
            GameObject clone;
            if (tag == "Player" && Input.GetButton("Jump") || Input.GetButton("Fire1")) {
                clone = Instantiate(blast, new Vector2(pos.x, pos.y + 3f), transform.rotation);
                clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * speed);

                //Instantiate(blast, new Vector2(pos.x, pos.y + 3f), transform.rotation).GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * speed);
            }
            if (tag == "Enemy") {
                clone = Instantiate(blast, new Vector2(pos.x, pos.y - 3f), Quaternion.Euler(180f, 0f, 0f));
                clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.down * speed);
            }
            lastFire = Time.time;
            //Destroy(clone, 2.0f);
        }
	}
}
