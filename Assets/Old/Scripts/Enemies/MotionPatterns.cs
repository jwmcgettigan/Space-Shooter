using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MotionPatterns : MonoBehaviour
{
    private float RotateSpeed = 2f;
    private float Radius;

    private Vector2 centre;
    private Vector3 pos;
    private Vector3 axis;

    private float angle;

    private int motionType;
    private int CLOCKWISE_CIRCULAR_MOTION = 1;
    private int ANTICLOCKWISE_CIRCULAR_MOTION = 2;
    private int S_MOTION = 3;
    private System.Random rnd;
    public float changeRate = 5f;
    private float lastChange = 0f;

    void Start()
    {
        InvokeRepeating("smallWave", 1f, 10f);
        centre = transform.position;
        pos = transform.position;
        axis = transform.right;

        rnd = new System.Random();
        //motionType = rnd.Next(1, 4);
        motionType = 3;
    }

    void Update() {
        if (motionType == CLOCKWISE_CIRCULAR_MOTION) {
            clockwiseCircularMotion();
        } else if (motionType == ANTICLOCKWISE_CIRCULAR_MOTION) {
            anticlockwiseCircularMotion();
        } else if (motionType == S_MOTION) {
            SMotion();
        }
        if (Time.time > changeRate + lastChange) {
            motionType = 1;
            lastChange = Time.time;
        }
    }

    private void smallWave() {
        //motionType = rnd.Next(1, 4);
    }

    private void clockwiseCircularMotion()
    {
        Radius = 40f;
        angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;
    }

    private void anticlockwiseCircularMotion()
    {
        Radius = 40f;
        angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;
        transform.position = centre + offset;
    }

    private void SMotion()
    {
        float MoveSpeed = 13.0f;
        float frequency = 5.0f;
        float magnitude = 10f;
        pos -= transform.up * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
