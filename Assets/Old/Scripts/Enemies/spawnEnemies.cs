using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawnEnemies : MonoBehaviour {

    public GameObject enemy;
    public float spawnRate = 0.2f;
    private float lastSpawn = 0f;
    private int motionType, rand;

    void Start () {
        InvokeRepeating("smallWave", 1f, 10f);
	}

    void Update() {
        if (Time.time > spawnRate + lastSpawn) {
            spawnEnemy();
            lastSpawn = Time.time;
        }
    }

    private void smallWave() {
        rand = (int)Random.Range(0f, 30f);
    }

    private void spawnEnemy() {
        Vector2 pos = transform.position;
        Instantiate(enemy, new Vector2(pos.x + rand, pos.y), transform.rotation); //improve random number generation
    }
}
