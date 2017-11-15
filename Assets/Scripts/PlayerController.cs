using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    public float speed = 30f;
    public float tilt;
    public Boundary boundary;

    private float hMove, vMove;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(hMove, vMove);
        rb.velocity = movement * speed;

        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
            );

        rb.rotation = rb.velocity.x * -tilt;
    }
}
