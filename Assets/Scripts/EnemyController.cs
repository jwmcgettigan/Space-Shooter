using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int motionType;

    private float RotateSpeed = 2f, Radius, angle;
    private Vector2 centre;
    private Vector3 pos, axis;

    // Use this for initialization
    void Start () {
        centre = transform.position;
        pos = transform.position;
        axis = transform.right;
    }
	
	// Update is called once per frame
	void Update () {
        if (motionType == 1) {
            clockwiseCircularMotion();
        } else if (motionType == 2) {
            anticlockwiseCircularMotion();
        } else if (motionType == 3) {
            SMotion();
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
