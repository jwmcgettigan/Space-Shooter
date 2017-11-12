using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectileLauncher : MonoBehaviour {

    public GameObject projectile;
    public float speed = 50f;
    public float fireRate = 0.2f;
    private float lastShot = 0f;
	
	// Use something other than fixed update so that the frequency can be changed by power ups.
	void Update () {
        if (Input.GetKey(KeyCode.Space)){ //Add controller support
            fire();
        }
	}

    private void fire(){
        Vector2 pos = transform.position;
        if(Time.time > fireRate + lastShot) {
            GameObject bullet = (GameObject)Instantiate(projectile, new Vector2(pos.x, pos.y + 3f), transform.rotation);
        
            bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * speed);
            lastShot = Time.time;
            Destroy(bullet, 3.0f);
        }
    }
}
