using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroller : MonoBehaviour {
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector2 startPosition;

    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector2.up * newPosition;
    }
}